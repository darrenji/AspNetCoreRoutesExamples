﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreRoutesExamples
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            //一种写法
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name:"default", 
            //        template:"{controller}/{action}",
            //        defaults: new { action="Index"});
            //});

            //另一种写法
            app.UseMvc(routes => {
                //routes.MapRoute(
                //    name:"ShopSchema2",
                //    template:"Shop/OldAction",
                //    defaults: new { controller="Home", action="Index"});

                //routes.MapRoute(
                //    name:"ShopSchema",
                //    template: "Shop/{action}",
                //    defaults:new {controller="Home"}
                //    );

                //routes.MapRoute("", "X{controller}/{action}");

                //routes.MapRoute(
                //    name:"default",
                //    template:"{controller=Home}/{action=Index}");

                //routes.MapRoute(
                //    name:"",
                //    template:"Public/{controller=Home}/{action=Index}");

                //都赋上默认值
                //routes.MapRoute(name:"MyRoute", template:"{controller=Home}/{action=Index}/{id=DefaultId}");

                //路由参数可空的情况
                //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id?}");

                //获取尾部多个参数的做法
                routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");
            });
        }
    }
}
