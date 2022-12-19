using food.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace food.Controllers
{
    public class HomeController : Controller
    {
        



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user a)
        {
            foodEntities1 foodentities = new foodEntities1();
            var login = (from c in foodEntities1.users where c.Name == a.Name && c.Password == a.Password select c);
            if (login != null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult collection()
        {
            return View();
        }
        [HttpGet]
        
        
    }
}