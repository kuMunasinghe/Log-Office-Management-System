using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Log_Office_Management_System.Models;
using System.Data.SqlClient;

namespace Log_Office_Management_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeAdmin
      public ActionResult Ledgers()
        {
            return Content("<script language='javascript' type='text/javascript'>alert('This is home page !');</script>");
        }

      
        
    }
}