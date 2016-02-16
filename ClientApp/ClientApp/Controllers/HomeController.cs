using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HttpCookie rqstCookie = Request.Cookies.Get("myCookie");

            if (rqstCookie == null)
            {
                return RedirectToAction("Login");
            }
            else if (rqstCookie.Value == null || rqstCookie.Value == "")
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            string userid = Request["userid"];
            var rqstCookie = new HttpCookie("myCookie");
            rqstCookie.Value = userid;

            DateTime curr = DateTime.Now;
            rqstCookie.Expires = curr.AddDays(3);

            Response.Cookies.Add(rqstCookie);
                
            return View();
        }
    }
}