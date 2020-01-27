using System.Text;
using AutoMapper;
using KislovBlog.Controllers.ModelConfig;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Services;
using KislovBlog.Middlewares;
using KislovBlog.Repository;
using KislovBlog.Utilities.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace KislovBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiProfile());
                mc.AddProfile(new DomainProfile());
            }).CreateMapper());

            var key = Encoding.ASCII.GetBytes(Configuration["App:Secret"]);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            //DB
            services.AddSingleton<IArticleRepository, ArticleRepository>();

            //Domain
            services.AddSingleton<ICensureChecker, CensureChecker>();
            services.AddScoped<IMessageWorker, MessageWorker>();

            //Api
            services.AddControllers();

            //Options
            services.Configure<AppOptions>(Configuration.GetSection("App"));
            services.Configure<AuthOption>(Configuration.GetSection("Auth"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<AuthMiddleware>();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
