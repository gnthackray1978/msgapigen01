using Serilog;
using Api.Schema.SubQueries;
using ConfigHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MSGSharedData.Data.Services;
using MSGSharedData.Data.Services.interfaces.services;
using AutoMapper;
using FTMContextNet.Data.Repositories.GedImports;
using FTMContextNet.Data.Repositories.GedProcessing;
using FTMContextNet.Data.Repositories.TreeAnalysis;
using FTMContextNet.Data;
using FTMContextNet.Domain.Caching;
using LoggingLib;
using Microsoft.Extensions.Hosting;
using MSGIdent;
using PlaceLibNet.Data.Contexts;
using PlaceLibNet.Data.Repositories;
using PlaceLibNet.Domain.Caching;
using PlaceLibNet.Domain;
using QuickGed.Domain;
using QuickGed.Services;
using System.Reflection;
using System;
using FTMContextNet.Application.Mapping;
using Api.Hub;
using Api.Controllers;
using GoogleMapsGeocoding;

namespace Api
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
        //    string MyAllowSpecificOrigin = "_myAllowSpecificOrigin";

            Serilog.Log.Information("RegisterServices");

        //    var builder = WebApplication.CreateBuilder(args);
            var msgConfigHelper = new MSGConfigHelper();

            var azureHelper = new AzureDBHelpers(msgConfigHelper.MSGGenDB01);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });

            builder.Services.AddAuthorization().AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(o =>
            {
                o.SecurityTokenValidators.Clear();
                o.SecurityTokenValidators.Add(new GoogleTokenValidator());
            });

            string[] o = { msgConfigHelper.ClientURLs };

            if (msgConfigHelper.ClientURLs.Trim().Contains(' '))
                o = msgConfigHelper.ClientURLs.Split(' ');

            builder.Services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins(o)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });


            builder.Services
                .AddSingleton<IMSGConfigHelper>(msgConfigHelper)
                .AddSingleton<IWillListRepository, WillListRepository>()
                .AddSingleton<IClaimRepository, ClaimRepository>()
                .AddSingleton<IADBRepository, ADBRepository>()
                .AddSingleton<IBlogRepository, BlogRepository>()
                .AddSingleton<IDiagramRepository, DiagramRepository>()
                .AddSingleton<IDNAAnalyseListRepository, DNAAnalyseRepository>()
                .AddSingleton<IPhotoListRepository, PhotoListRepository>()
                .AddSingleton<IFunctionListRepository, SiteFunctionRepository>()
                .AddSingleton<ISiteListRepository, SiteListRepository>()
                .AddSingleton<INodeTypeCalculator>(new NodeTypeCalculator())
                .AddSingleton<IMapper>(config.CreateMapper())
                .AddSingleton<IAuth>(new Auth())
                .AddSingleton<IPlaceNameFormatter>(new PlaceNameFormatter())
                .AddSingleton<IMSGConfigHelper>(msgConfigHelper)
                .AddSingleton<IAzureDBHelpers>(azureHelper)
                .AddTransient<Ilog, OutputHandler>()
                .AddTransient<IGedParser, GedParser>()
                .AddTransient<IGedRepository, GedRepository>()
                .AddTransient<IPlacesContext, AzurePlacesContext>()
                .AddTransient<IPersonPlaceCache, PersonPlaceCache>()
                .AddTransient<IGeocoder,GoogleMapsGeocoding.Geocoder>()
                .AddTransient<IPersistedCacheContext, AzurePersistedCacheContext>()
                .AddTransient<IPersistedImportCacheRepository, PersistedImportCacheRepository>()
                .AddTransient<IPersistedCacheRepository, PersistedCacheRepository>()
                .AddTransient<IPlaceLibCoordCache, PlaceLibCoordCache>()
                .AddTransient<IPlaceLookupCache, PlaceLookupCache>()
                .AddTransient<IPlaceRepository, PlaceRepository>()
                .AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddTypeExtension<ADBQuery>()
                .AddTypeExtension<BlogQuery>()
                .AddTypeExtension<ClaimQuery>()
                .AddTypeExtension<DiagramQuery>()
                .AddTypeExtension<DNAQuery>()
                .AddTypeExtension<ImageQuery>()
                .AddTypeExtension<SiteFunctionQuery>()
                .AddTypeExtension<SiteQuery>()
                .AddTypeExtension<WillQuery>();

            builder.Services
                .AddMediatR(cfg => cfg
                    .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddSignalR();
                  // TURNED OFF AZURE SIGNALR BY COMMENTING THIS OUT
                  // AND NOTHING ELSE
                  //  .AddAzureSignalR(msgConfigHelper.SigRConnStr);

            //PersistedImportCacheRepository
            builder.Services.AddControllers();

            return builder;
        }
    }

    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            
            Serilog.Log.Information("SetupMiddleware");

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("default");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(e =>
            {
                e.MapHub<MsgNotificationHub>("/hub/msgnotificationhub");
                e.MapControllers();
            });

            app.MapGraphQL();

            return app;
        }
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                           .WriteTo.Debug()
                           .WriteTo.Console()
                           .WriteTo.File("log.txt")
                           .CreateBootstrapLogger();

            Serilog.Log.Information("Starting up");

            Console.Title = "API";

            WebApplication app = WebApplication.CreateBuilder(args)
                .RegisterServices()
                .Build();

            app.SetupMiddleware()
                .Run();
        }
         
    }
}