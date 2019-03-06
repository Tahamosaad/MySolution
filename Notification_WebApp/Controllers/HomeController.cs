using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Notification_WebApp.Controllers
{
    public class HomeController : Controller
    {
        Notification_DBEntities db = new Notification_DBEntities();
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(Notification mdl)
        {
            return View();
        }
        private static List<tbl_cust> Userlist()
        {
          //  string lblErrorMessage = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49632/");

                var response2 = client.GetAsync("api/login/getCustomerInfo").Result;

                string res = "";
                using (HttpContent content = response2.Content)
                {
                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    res = result.Result;
                }

                if (res.ToString().Trim() == "0")
                {
                    //TempData["Failed"] =  "Invalid login credentials.";

                    return null;

                }
                else
                {

                    //TempData["success"] = "Loggedin successfully.";

                    List<tbl_cust> ntf = JsonConvert.DeserializeObject<List<tbl_cust>>(res.ToString());
                    return ntf;
                    
                    

                }
            }
        }
        
        public PartialViewResult _RenderUsers()
        {
            return PartialView(Userlist());
        }

       
        public PartialViewResult _RenderNotification()
        {
          
            return PartialView();
        }

    }
}