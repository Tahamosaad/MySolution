using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace Notification_API.Controllers
{
    public class HomeController : Controller
    {

        //The data should come from database but here I am hard coding it.    
        public static List<UsersModel> users_list = new List<UsersModel>
        {
            new UsersModel { id = 1, name = "taha", role = "admin" },
            new UsersModel { id = 2, name = "user1", role = "customer" }
         
        };
        [HttpGet]
        public List<UsersModel> Get()
        {
            return users_list;
        }

        [HttpGet]
        public UsersModel Get(int id)
        {
            return users_list.Find((r) => r.id == id);
        }

        [HttpPost]
        public bool Post(UsersModel report)
        {
            try
            {
                users_list.Add(report);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                var itemToRemove = users_list.Find((r) => r.id == id);
                users_list.Remove(itemToRemove);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
