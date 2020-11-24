using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Collections;

using BootStrapMVCDev.DAC;
using BootStrapMVCDev.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;


namespace BootStrapMVCDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        //public String Index()
        //{

        //    // https://stackoverflow.com/questions/38778183/retrieving-connection-string-from-environment-variables
        //    // ConnectionStrings:DefaultConnection=Server=(localdb)\\MSSQLLocalDB;Database=_CHANGE_ME_ENV;Trusted_Connection=True;MultipleActiveResultSets=true
        //    //
        //    string connString = this.Configuration.GetConnectionString("DefaultConnection");


        //    StaffTableDAC staffTableDAC = new StaffTableDAC(connString);
        //    StaffList aList = staffTableDAC.GetStaffList();
        //    string s1 = string.Empty;
        //    foreach (Staff aItem in aList)
        //    {
        //        s1 += aItem.UserID + " " + aItem.PersonnelName + "\n";
        //    }

        //    return s1;
        //}

        public ViewResult Index()
        {
            return View("Modal01View");
        }


        public String ModalFormAction()
        {
            string connString = this.Configuration.GetConnectionString("DefaultConnection");

            StaffTableDAC staffTableDAC = new StaffTableDAC(connString);
            string userID = HttpContext.Request.Form["userid"], password = HttpContext.Request.Form["password"];
            bool okUserID = staffTableDAC.CheckUserID(userID, password);

            string idMessage = string.Empty;
            if (okUserID)
            {
                idMessage = "ID is OK";
            }
            else
            {
                idMessage = "ID is nope";
            }


            string str1 = HttpContext.Request.Form["firstName"] + " " + HttpContext.Request.Form["lastName"];
            str1 = str1 + "\n" + connString;
            str1 = str1 + "\n" + userID + " "+password;
            str1 = str1 + "\n" + idMessage;


            return "ModalFormAction is here. firstName: " +str1;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
