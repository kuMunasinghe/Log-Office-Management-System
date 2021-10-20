using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Log_Office_Management_System.Models;
using System.Data.SqlClient;


namespace Log_Office_Management_System.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View("AdminLogin");
        }
       
         
    void connectionString()
        {
            con.ConnectionString = "data source=MSI;database=log_office_mng; Integrated security=SSPI;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select *from login_data where UserId='" + acc.UserID + "' and Pswd='" + acc.Password + "'and UserStat=0";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                
                con.Close();
                return Content("<script language='javascript' type='text/javascript'>alert('Login Successfully !');</script>");
            }
            else
            {
                con.Close();

                return Content("<script language='javascript' type='text/javascript'>alert('Check User Crediantials !');</script>");
            }
           
           
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyAdmin(Account acc)
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select *from login_data where UserId='" + acc.UserID + "' and Pswd='" + acc.Password + "'and UserStat=1";
            dr = com.ExecuteReader();
            if (dr.Read())
            {

                con.Close();
                return View("~/Views/HomeAdmin/Home.cshtml");
            }
            else
            {
                con.Close();
                return Content("<script language='javascript' type='text/javascript'>alert('Check User Crediantials');</script>");
                

            }
        }
    }
}