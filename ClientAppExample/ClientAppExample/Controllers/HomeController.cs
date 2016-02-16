using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientAppExample.Controllers
{
    public class HomeController : Controller
    {
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
                ViewBag.userid = Request.Cookies["myCookie"].Value;
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {

            string userid = Request["userid"];
            var rqstCookie = new HttpCookie("myCookie");
            rqstCookie.Value = userid;

            DateTime curr = DateTime.Now;
            rqstCookie.Expires = curr.AddDays(7);
            rqstCookie.Secure = false;

            Response.Cookies.Add(rqstCookie);
            Response.AddHeader("Access-Control-Allow-Origin", "*");

            return View();
        }
    }
}