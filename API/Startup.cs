
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;

using Api.Services;
using Api.Types;
using Api.Models;
using Api.Types.DNAAnalyse;
using Api.Schema;
using Api.Types.ADB;
using Api.Types.Images;
using Api.Types.Diagrams;
using Api.Schema.SubQueries;
using Api.Services.interfaces.services;
using Api.Types.Blog;

using ConfigHelper;
using Serilog;

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

            services.AddAuthentication(options =>
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

            //5003 was the client
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins(o)
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
            services.AddHttpClient<IDiagramService, DiagramService>();
            services.AddHttpClient<IBlogService, BlogService>();

            services.AddSingleton<ClaimQuery>();
            services.AddSingleton<SiteQuery>();
            services.AddSingleton<SiteFunctionQuery>();
            services.AddSingleton<WillQuery>();
            services.AddSingleton<DNAQuery>();
            services.AddSingleton<ADBQuery>();
            services.AddSingleton<ImageQuery>();
            services.AddSingleton<DiagramQuery>();
            services.AddSingleton<BlogQuery>();

            services.AddSingleton<ApiImagesType>();
            services.AddSingleton<ApiParentImagesType>();
            services.AddSingleton<MSGClaimType>();
            services.AddSingleton<SiteType>();
            services.AddSingleton<SiteFunctionType>();
            services.AddSingleton<WillType>();
            services.AddSingleton<BlogType>();

            services.AddSingleton<FTMPersonLocationType>();
            services.AddSingleton<FTMPersonSummaryType>();
            services.AddSingleton<FTMLatLngType>();
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

            services.AddSingleton<AncestorNodeType>();
            services.AddSingleton<DescendantNodeType>();

            services.AddSingleton<WillResultType<WillType, Will>>();

            services.AddSingleton<ClaimResultType<MSGClaimType, MSGClaim>>();
            services.AddSingleton<SiteResultType<SiteType, Site>>();
            services.AddSingleton<SiteFunctionResultType<SiteFunctionType, SiteFunction>>();
            
            
            //
            services.AddSingleton<AncestorResult>();
            services.AddSingleton<DescendantResult>();

            services.AddSingleton<ApiParentImagesResult>();
            services.AddSingleton<ApiImagesResult>();
            services.AddSingleton<BlogListResult>();
            services.AddSingleton<DupeResult>();
            services.AddSingleton<FTMViewResult>();
            services.AddSingleton<FTMLatLngResult>();

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
            app.UseGraphQLPlayground("/");
            app.UseGraphQLVoyager("/voyager" );

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