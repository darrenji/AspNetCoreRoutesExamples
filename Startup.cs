using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Routing;
using AspNetCoreRoutesExamples.Infrastructure;

namespace AspNetCoreRoutesExamples
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //自定义行内约束
            services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

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
            //app.UseMvc(routes => {
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
            //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id?}/{*catchall}");

            //对路由参数约束
            //routes.MapRoute(name: "MyRoute", template: "{controller=Home}/{action=Index}/{id:int?}");

            //对路由参数的另外一种约束方法，约束单独列
            //routes.MapRoute(
            //    name: "MyDefault",
            //   template:"{controller}/{action}/{id?}",
            //   defaults:new { controller="Home", action="Index"},
            //   constraints:new { id= new IntRouteConstraint()});

            //正则表达式约束1
            //routes.MapRoute(
            //    name:"MyRoute",
            //    template:"{controller:regex(^H.*)=Home}/{action=Index}/{id?}");

            //正则表达式约束2
            //routes.MapRoute(
            //    name: "MyRoute",
            //    template: "{controller:regex(^H.*)=Home}/"
            //        + "{action:regex(^Index$|^About$)=Index}/{id?}");

            //值类型约束
            //routes.MapRoute(
            //    name:"MyRoute",
            //    template:"{controller=Home}/{action=Index}/{id:range(10,20)}");

            //混合约束
            //routes.MapRoute(
            //    name:"MyRoute",
            //    template:"{controller=Home}/{action=Index}" + "/{id:alpha:minlength(6)?}");

            //使用系统类约束
            //routes.MapRoute(
            //    name: "MyRoute",
            //    template: "{controller}/{action}/{id?}",
            //    defaults: new { controller = "Home", actiion = "Index" },
            //    constraints: new {
            //        id = new CompositeRouteConstraint(new IRouteConstraint[] {
            //            new AlphaRouteConstraint(),
            //            new MinLengthRouteConstraint(6)
            //        })
            //    });

            //使用自定义约束类
            //routes.MapRoute(name:"MyRoute",
            //    template:"{controller}/{action}/{id?}",
            //    defaults:new { controller="Home", actioin="Index"},
            //    constraints:new { id=new WeekDayConstraint()});

            //自定义行内约束
            //routes.MapRoute(name:"MyDefault",
            //    template:"{controller=Home}/{action=Index}/{id:weekday}");
            //);

            //属性路由
            //app.UseMvcWithDefaultRoute();


            //------------------------------
            // 高级路由
            //------------------------------
            //app.UseMvc(routes => {
            //    //routes.MapRoute(
            //    //    name:"NewRoute",
            //    //    template:"App/Do{action}",
            //    //    defaults:new { controller="Home"});

            //    routes.MapRoute(
            //        name:"default",
            //        template:"{controller=Home}/{action=Index}/{id?}");


            //    routes.MapRoute(
            //        name:"out",
            //        template:"outbound/{controller=Home}/{action=Index}");
            //});

            app.UseMvc(routes => {
                routes.MapRoute(name:"areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(name:"MyDefault",
                    template:"{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name:"out",
                    template:"outbound/{controller=Home}/{action=Index}");
            });
        }
    }
}
