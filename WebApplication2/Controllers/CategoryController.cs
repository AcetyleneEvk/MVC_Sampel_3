using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        [ChildActionOnly] //只能由子要求存取
        public ActionResult _CategoryMenu()
        {

            SqlHelper sqlHelper = new SqlHelper();
            List<SqlParameter> paralist = new List<SqlParameter>();
            DataTable dt = sqlHelper.SqlQuery("Select * From TEST_Table", paralist);
            paralist.Add(new SqlParameter("@ID", "123"));
            List<CategoryEnity> result = new List<CategoryEnity>();



            result = (from DataRow dr in dt.Rows
                      select new CategoryEnity()
                      {
                          ID = dr["ID"].ToString(),
                          userName = dr["userName"].ToString(),
                          userPassword = dr["userPassword"].ToString()
                      }).ToList();
            //using (CategoryEnity db = new CategoryEnity())
            //{
            //    result = (from s in db.CategorySet select s).ToList();

            //}
            return PartialView("_CategoryMenu", result);
            //把DB資料撈出來傳到_CategoryMenu
        }
    }
}