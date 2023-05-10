using sampleApp.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sampleApp.Areas.Admin.Controllers
{
    public class AdminBeforeLoginController : Controller
    {
        // GET: Admin/AdminBeforeLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            try
            {
                AdminModel am = new AdminModel();
                am.uname = fc["uname"].ToString();
                am.upass = fc["upass"].ToString();
                am = am.checkLogin();
                if (am.id != 0)
                {

                    Session["udata"] = am;
                    //Session.Add("uData",am);
                    //ViewBag.statusMsg = "Success";
                    return RedirectToAction("AdminHome");
                }
                else {
                    ViewBag.statusMsg = "Invalid Username or Password";
                }
            }
            catch (Exception e)
            {
                ViewBag.statusMsg = "Unable to Login, Please try again later!!";
            }
            return View();
        }

        public ActionResult AdminHome() {

            if (!checkSession()) {
                return RedirectToAction("Index");
            }
            return View();

        }

        public bool checkSession() {
            if (Session["uData"] != null) {
                return true;
            }
            else {
                return false;
            }
        }

       

    }
}