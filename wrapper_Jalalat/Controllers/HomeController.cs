using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wrapper;

namespace wrapper_Jalalat.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Convertor cto = new Convertor();
           var hh=  cto.CheckConnection();
            //var ss = cto.GetPersonGeneriv<Person>();
            //var ss = cto.GetPersonHttp();
            var ss = cto.GetPersonWithRouting();
            return View();
        }
    }
}