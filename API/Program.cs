using Serilog;
using Api.Schema.SubQueries;
using Api.Services;
using Api.Services.interfaces.services;
using ConfigHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Query
    {

    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateBootstrapLogger();

            Log.Information("Starting up");

            var builder = WebApplication.CreateBuilder(args);
            var msgConfigHelper = new MSGConfigHelper();
             
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

            builder.Services
                .AddSingleton<IMSGConfigHelper>(msgConfigHelper)
                .AddSingleton<IWillListService, WillListService>()
                .AddSingleton<IClaimService, ClaimService>()
                .AddSingleton<IADBService, ADBService>()
                .AddSingleton<IBlogService, BlogService>()
                .AddSingleton<IDiagramService, Api.Services.DiagramService>()
                .AddSingleton<IDNAAnalyseListService, DNAAnalyseService>()
                .AddSingleton<IPhotoListService, PhotoListService>()
                .AddSingleton<IFunctionListService, SiteFunctionService>()
                .AddSingleton<ISiteListService, SiteListService>()
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
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseCors("default");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGraphQL();

            app.Run();
        }
         
    }
}