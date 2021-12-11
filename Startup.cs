
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using GraphQL;
using GqlMovies.Api.Services;
using GqlMovies.Api.Schemas;
using GqlMovies.Api.Types;
using GqlMovies.Api.Models;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using Api.Services.interfaces;
using Api.Types.DNAAnalyse;
using Api.Schema;
using Api.Types.ADB;

using System;
using ConfigHelper;
using Api.Types.Images;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
           // Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
       
             
            //services.AddTransient()
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddMvcCore()//(o=>o.EnableEndpointRouting =false)
                .AddAuthorization()
                .AddNewtonsoftJson();

          
            var msgConfigHelper = new MSGConfigHelper();

            services.AddSingleton<IMSGConfigHelper>(msgConfigHelper);

            //5000 was the auth server
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = msgConfigHelper.AuthServerUrl;
                    options.RequireHttpsMetadata = false;

                    options.Audience = "api1";
                });

            //5003 was the client
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins(msgConfigHelper.TestClientUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

          //  services.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);

            services.AddSingleton(s => new MainSchema( new FuncServiceProvider(type => (IGraphType)s.GetRequiredService(type))));


            services.AddHttpClient<IClaimService, ClaimService>();
            services.AddHttpClient<ISiteListService, SiteListService>();
            services.AddHttpClient<IFunctionListService, SiteFunctionService>();
            services.AddHttpClient<IWillListService, WillListService>();
            services.AddHttpClient<IDNAAnalyseListService, DNAAnalyseService>();
            services.AddHttpClient<IADBService, ADBService>();
            services.AddHttpClient<IPhotoListService, PhotoListService>();


            services.AddSingleton<ClaimQuery>();
            services.AddSingleton<SiteQuery>();
            services.AddSingleton<SiteFunctionQuery>();
            services.AddSingleton<WillQuery>();
            services.AddSingleton<DNAQuery>();
            services.AddSingleton<ADBQuery>();
            services.AddSingleton<ImageQuery>();

            services.AddSingleton<ApiImagesType>();
            services.AddSingleton<ApiParentImagesType>();

            services.AddSingleton<MSGClaimType>();
            services.AddSingleton<SiteType>();
            services.AddSingleton<SiteFunctionType>();
            services.AddSingleton<WillType>();

            services.AddSingleton<FTMPersonLocationType>();
            services.AddSingleton<FTMPersonSummaryType>();

            services.AddSingleton<FTMViewType>();
            services.AddSingleton<TreeRecType>();
            services.AddSingleton<PersonOfInterestType>();
            services.AddSingleton<DupeType>();

            services.AddSingleton<ADBMarriageType>();
            services.AddSingleton<ADBPersonType>();
            services.AddSingleton<ADBSourceType>();
            services.AddSingleton<ADBParishType>();
            services.AddSingleton<ADBISourceType>();


            services.AddSingleton<ADBISourceType>();

         


            services.AddSingleton<WillResultType<WillType, Will>>();

            services.AddSingleton<ClaimResultType<MSGClaimType, MSGClaim>>();
            services.AddSingleton<SiteResultType<SiteType, Site>>();
            services.AddSingleton<SiteFunctionResultType<SiteFunctionType, SiteFunction>>();


            services.AddSingleton<ApiParentImagesResult>();
            services.AddSingleton<ApiImagesResult>();
            services.AddSingleton<DupeResult>();
            services.AddSingleton<FTMViewResult>();
            
            services.AddSingleton<FTMPersonLocationResult>();
            services.AddSingleton<PersonOfInterestResult>();
            services.AddSingleton<TreeRecResult>();
            services.AddSingleton<MarriageSearchResult>();
            services.AddSingleton<PersonSearchResult>();
            services.AddSingleton<ParishSearchResult>();
            services.AddSingleton<SourceSearchResult>();

            services.AddSingleton<MainSchema>();
            
            services.AddControllers().AddNewtonsoftJson();

            

        }

        public void Configure(IApplicationBuilder app)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHttpsRedirection();
            //}

            app.UseCors("default");
            app.UseAuthentication();
            // app.UseMvc();

            app.UseWebSockets();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions() { Path = "/" });
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions() { Path = "/voyager" });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        
        
        //.UseWebSockets()
        //    .UseGraphQLPlayground(new GraphQLPlaygroundOptions() { Path = "/" })
        //    .UseGraphQLVoyager(new GraphQLVoyagerOptions() { Path = "/voyager" });
         
        }
    }
}