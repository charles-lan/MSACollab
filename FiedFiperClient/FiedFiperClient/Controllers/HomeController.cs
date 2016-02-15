using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiedFiperClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie rqstcookie = Request.Cookies.Get("mycookie");

            if (rqstcookie == null)
            {
                return RedirectToAction("Login");
            } else if (rqstcookie.Value == null || rqstcookie.Value == "")
            {
                return RedirectToAction("Login");
            } else
            {
                return View();
            }
        }

        public ActionResult Login ()
        {

            string userid = Request["userid"];
            var rqstCookie = new HttpCookie("mycookie");
            rqstCookie.Value = userid;

            DateTime curr = DateTime.Now;
            rqstCookie.Expires = curr.AddDays(7);

            Response.Cookies.Add(rqstCookie);

            return View();
        }
    }
}