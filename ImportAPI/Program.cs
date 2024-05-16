using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ConfigHelper;
using FTMContextNet.Data.Repositories.GedImports;
using FTMContextNet.Data.Repositories.GedProcessing;
using FTMContextNet.Data.Repositories.TreeAnalysis;
using FTMContextNet.Data;
using FTMContextNet.Domain.Caching;
using ImportAPI.Controllers;
using LoggingLib;
using MSGIdent;
using PlaceLibNet.Data.Contexts;
using PlaceLibNet.Data.Repositories;
using PlaceLibNet.Domain.Caching;
using PlaceLibNet.Domain;
using QuickGed.Domain;
using QuickGed.Services;
using System.Reflection;
using FTMContextNet.Application.Mapping;
using ImportAPI.Hub;

namespace ImportAPI
{
    public static class RegisterDependentServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        { 
            string MyAllowSpecificOrigin = "_myAllowSpecificOrigin";

            Serilog.Log.Information("RegisterServices");

            var msgConfigHelper = new MSGConfigHelper(false);

            

            var azureHelper = new AzureDBHelpers(msgConfigHelper.MSGGenDB01);
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            
            builder.Services
                .AddCors(options =>
                {
                    options.AddPolicy(MyAllowSpecificOrigin, builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
                })
                    .AddSingleton<IMSGConfigHelper>(msgConfigHelper)
                    .AddSingleton<IAzureDBHelpers>(azureHelper)
                    .AddMediatR(cfg => cfg
                    .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                    .AddTransient<Ilog, OutputHandler>()
                    .AddSingleton<INodeTypeCalculator>(new NodeTypeCalculator())
                    .AddSingleton<IMapper>(config.CreateMapper())
                    .AddSingleton<IAuth>(new Auth())
                    .AddSingleton<IPlaceNameFormatter>(new PlaceNameFormatter())
                    .AddTransient<IGedParser, GedParser>()
                    .AddTransient<IGedRepository, GedRepository>()
                    .AddTransient<IPlacesContext, AzurePlacesContext>()
                    .AddTransient<IPersonPlaceCache, PersonPlaceCache>()
                    .AddTransient<IPersistedCacheContext, AzurePersistedCacheContext>()
                    .AddTransient<IPersistedImportCacheRepository, PersistedImportCacheRepository>()
                    .AddTransient<IPersistedCacheRepository, PersistedCacheRepository>()
                    .AddTransient<IPlaceLibCoordCache, PlaceLibCoordCache>()
                    .AddTransient<IPlaceLookupCache, PlaceLookupCache>()
                    .AddTransient<IPlaceRepository, PlaceRepository>()
                 
                    .AddSignalR().AddAzureSignalR(msgConfigHelper.SigRConnStr); 

            //PersistedImportCacheRepository
            builder.Services.AddControllers();

            return builder;
        }
    }

    public static class SetupMiddlewarePipeline
    {
        public static WebApplication SetupMiddleware(this WebApplication app)
        {
            string MyAllowSpecificOrigin = "_myAllowSpecificOrigin";

            Serilog.Log.Information("SetupMiddleware");

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigin);

            app.UseAuthorization();
 
            app.UseEndpoints(e =>
            {
                e.MapHub<MsgNotificationHub>("/hub/MsgNotificationHub");
                e.MapControllers();
            });

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

            Console.Title = "Input API";

            WebApplication app = WebApplication.CreateBuilder(args)
                .RegisterServices()
                .Build();
            
            app.SetupMiddleware()
                .Run();

        }
        
    }
}
