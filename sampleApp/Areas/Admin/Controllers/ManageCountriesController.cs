using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sampleApp.Areas.Admin.Controllers
{
    public class ManageCountriesController : Controller
    {
        // GET: Admin/ManageCountries
        public ActionResult Index()
        {
            return View();
        }
    }
}