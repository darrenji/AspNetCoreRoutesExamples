using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRoutesExamples.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreRoutesExamples.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Result", new Result {
                Controller=nameof(HomeController),
                Action=nameof(Index)
            });
        }

        public ViewResult CustomVariable(string id) {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            //从路由中获取：/CustomVariable/hello
            //r.Data["id"] = RouteData.Values["id"];

            //这种方式也会到路由中去找id
            //可能本质是都放在RouteData.Values中了
            //r.Data["id"] = id;


            //路由参数可空的情况
            r.Data["id"] = id ?? "<no value>";

            return View("Result", r);
        }
    }
}
