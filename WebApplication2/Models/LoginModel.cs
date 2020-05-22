using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class LoginModel
    {
        public bool WriteSQL(string userName,string userPasswrod)
        {
            SqlHelper sqlHelper = new SqlHelper();

            string quString = @"INSERT INTO [dbo].[TEST_Table]
                   ([ID]
                   ,[Remark]
                   ,[userName]
                   ,[userPassword])
             VALUES
                   (@ID
                   ,@Remark
                   ,@userName
                   ,@userPassword);";
            List<SqlParameter> paralist = new List<SqlParameter>();
            paralist.Add(new SqlParameter("@ID", "123"));
            paralist.Add(new SqlParameter("@Remark", ""));
            paralist.Add(new SqlParameter("@userName", userName));
            paralist.Add(new SqlParameter("@userPassword", userPasswrod));

            sqlHelper.SqlCommit(quString, paralist);
            return true;
        }
    }
}