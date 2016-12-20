using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicationTrackFinal.Controllers
{
                                                                    //[AllowAnonymous] <<<<<<<<<<<<<I understand this data annotation would be placed somewhere where this would allow the public to view
                                                                    //unfortunately I just left it as so because of course this would be allowed in the public view anyway

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "MediTrack Solutions L.L.C.";

            return View();
        }
    }
}