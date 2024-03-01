using Serilog;
using Api.Schema.SubQueries;
using ConfigHelper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MSGSharedData.Data.Services;
using MSGSharedData.Data.Services.interfaces.services;

namespace Api
{
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
                .AddSingleton<IWillListRepository, WillListRepository>()
                .AddSingleton<IClaimRepository, ClaimRepository>()
                .AddSingleton<IADBRepository, ADBRepository>()
                .AddSingleton<IBlogRepository, BlogRepository>()
                .AddSingleton<IDiagramRepository, DiagramRepository>()
                .AddSingleton<IDNAAnalyseListRepository, DNAAnalyseRepository>()
                .AddSingleton<IPhotoListRepository, PhotoListRepository>()
                .AddSingleton<IFunctionListRepository, SiteFunctionRepository>()
                .AddSingleton<ISiteListRepository, SiteListRepository>()
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