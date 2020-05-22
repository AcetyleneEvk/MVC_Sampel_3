using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        GlobalFunction globalFunction = new GlobalFunction();
        public ActionResult Index()
        {
            ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
            return View();
        }


    }
}