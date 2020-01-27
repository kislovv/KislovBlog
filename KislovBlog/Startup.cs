using AutoMapper;
using KislovBlog.Controllers.ModelConfig;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Services;
using KislovBlog.Middlewares;
using KislovBlog.Repository;
using KislovBlog.Utilities.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
