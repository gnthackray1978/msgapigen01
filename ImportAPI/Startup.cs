//using System;
//using System.Reflection;
//using AutoMapper;
//using ConfigHelper;
//using FTMContextNet.Application.Mapping;
//using FTMContextNet.Data;
//using FTMContextNet.Data.Repositories.GedImports;
//using FTMContextNet.Domain.Caching;
//using ImportAPI.Controllers;
//using MSGIdent;
//using ImportAPI.Hub;
//using LoggingLib;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.SignalR;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using PlaceLibNet.Data.Contexts;
//using PlaceLibNet.Data.Repositories;
//using PlaceLibNet.Domain;
//using PlaceLibNet.Domain.Caching;
//using QuickGed.Domain;
//using QuickGed.Services;
//using FTMContextNet.Data.Repositories.GedProcessing;
//using FTMContextNet.Data.Repositories.TreeAnalysis;
//using Microsoft.Extensions.Logging;




//namespace ImportAPI
//{



//    public class Startup
//    {
//        private ILogger logger;

//        public Startup(IConfiguration configuration, ILogger logger)
//        {
//            Configuration = configuration;

//            logger = this.logger;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            logger.Log(LogLevel.Information, "fred");
//            var msgConfigHelper = new MSGConfigHelper();
//            var azureHelper = new AzureDBHelpers(msgConfigHelper.MSGGenDB01);

            

//            var config = new MapperConfiguration(cfg =>
//            {

//                cfg.AddProfile(new AutoMapperConfiguration());
//            });

//            // var hubContext = app.ApplicationServices.GetService < IHubContext < Notification >>
//            //.AddSingleton<IAzureDBHelpers(Azure)


//            services.AddSingleton<IMSGConfigHelper>(msgConfigHelper)
//                    .AddSingleton < IAzureDBHelpers>(azureHelper)
//                    .AddMediatR(cfg => cfg
//                    .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
//                    .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
//                    //.AddSingleton<Ilog>(new Log())
//                    .AddTransient<Ilog, OutputHandler>()
//                    .AddSingleton<INodeTypeCalculator>(new NodeTypeCalculator())
//                    .AddSingleton<IMapper>(config.CreateMapper())
//                    .AddSingleton<IAuth>(new Auth())
//                    .AddSingleton<IPlaceNameFormatter>(new PlaceNameFormatter())
//                    .AddTransient<IGedParser, GedParser>()
//                    .AddTransient<IGedRepository, GedRepository>()
//                    .AddTransient<IPlacesContext, AzurePlacesContext>()
//                    .AddTransient<IPersonPlaceCache,PersonPlaceCache>()
//                    .AddTransient<IPersistedCacheContext, AzurePersistedCacheContext>()
//                    .AddTransient<IPersistedImportCacheRepository, PersistedImportCacheRepository>()
//                    .AddTransient<IPersistedCacheRepository, PersistedCacheRepository>()
//                    .AddTransient<IPlaceLibCoordCache, PlaceLibCoordCache>()
//                    .AddTransient<IPlaceLookupCache,PlaceLookupCache>()
//                    .AddTransient<IPlaceRepository,PlaceRepository>();
            
//            //PersistedImportCacheRepository
//            services.AddControllers();
//            services.AddSignalR();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseHttpsRedirection();

//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//                endpoints.MapHub<MsgNotificationHub>("MsgNotificationHub");
//            }); 
//        }
//    }
//}
