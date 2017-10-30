using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATP2.Profile.Models.ReportModels;

namespace ATP2.Profile.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult StatisticReport()
        {
            return View(new StatisticReport());
        }

        public ActionResult ActivityReport()
        {
            return View();
        }

    }
}