using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ICinemaServices, CinemaMemoryService>();
            services.AddSingleton<IMovieServices, MovieMemoryServices>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }
            app.UseStatusCodePages();           //显示错误信息
            app.UseStaticFiles();               //加载静态文件

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});


            //app.Use(async (content,next) =>
            //{
            //    logger.LogInformation("M1 Start");
            //    await content.Response.WriteAsync("Hello World!");
            //    await next();
            //    logger.LogInformation("M1 end");
            //});

            //app.Run(async (content) =>
            //{
            //    logger.LogInformation("M2 Start");
            //    await content.Response.WriteAsync("Anther Hello!");
            //    logger.LogInformation("M2 end");
            //});


            app.UseEndpoints(endpoint =>
              {
                  endpoint.MapControllerRoute(
                          name: "default",
                          pattern: "{controller=Home}/{action=Index}/{id?}");
                  endpoint.MapRazorPages();
              });

        }
    }
}
