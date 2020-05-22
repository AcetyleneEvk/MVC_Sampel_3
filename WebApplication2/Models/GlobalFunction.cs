using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class GlobalFunction
    {
        public string LoginControl(object SessionString)
        {
            if (SessionString == null || SessionString.ToString() == "")
                return "登入";
            else
                return "登出";
        }
    }
}