using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRoutesExamples.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreRoutesExamples.Controllers
{
    [Route("app/[controller]/actions/[action]/{id?}")]
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        //[Route("myroute")]
        //[Route("[controller]/MyAction")]
        public IActionResult Index()
        {
            return View("Result", new Result {
                Controller=nameof(CustomerController),
                Action=nameof(Index)
            });
        }

        public ViewResult List(string id)
        {
            Result r = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };
            r.Data["id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }


    }
}
