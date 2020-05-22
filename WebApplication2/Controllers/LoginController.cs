using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication2.Models;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        GlobalFunction globalFunction = new GlobalFunction();


        //LoginViwe
        public ActionResult Login()
        {
            if (Session["usrName"] == null)
            {
                ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
                ViewBag.Message = "Please input your Account";
                ViewBag.Title = "Login Page";
                return View();
            }
            else
            {
                System.Web.HttpContext.Current.Session["usrName"] = null;
                ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
                ViewBag.UserName = Session["usrName"];
                return View("Login");
            }

        }


        //ReportViwer_Project
        public ActionResult ReportViewer_Project()
        {
            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> paralist = new List<SqlParameter>();
            DataTable dt = sqlHelper.SqlQuery("Select * From TEST_Table", paralist);
            paralist.Add(new SqlParameter("@ID", "123"));
            
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.Width = Unit.Pixel(1024);
            reportViewer.Height = Unit.Pixel(800);
            //reportViewer.Visible = false;
            reportViewer.LocalReport.ReportPath = $"{Request.MapPath(Request.ApplicationPath)}Report\\TESTReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
            ViewBag.ReportViewer = reportViewer;
            return View(reportViewer);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Texts(string username, string userpassword)
        {
            if (Session["usrName"] == null)
            {
                ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
                LoginModel loginModel = new LoginModel();
                bool LoginStatus = true;
                if (username == "")
                {
                    ViewBag.ErrorMessage = "請確認輸入的帳號!";
                    LoginStatus = false;
                }
                if (userpassword == "")
                {
                    ViewBag.ErrorMessage = "請確認輸入的密碼!";
                    LoginStatus = false;
                }

                if (!LoginStatus)
                    return View("Login");

                if (loginModel.WriteSQL(username, userpassword))
                {
                    System.Web.HttpContext.Current.Session["usrName"] = username;
                    ViewBag.UserLogin = "登出";
                    ViewBag.UserName = Session["usrName"];

                    return View("~/Views/Home/About.cshtml");
                }
                else
                    return View("Login");
            }
            else
            {
                ViewBag.UserName = Session["usrName"];
                ViewBag.UserLogin = globalFunction.LoginControl(Session["usrName"]);
                return View("~/Views/Home/About.cshtml");
            }

        }
    }

}