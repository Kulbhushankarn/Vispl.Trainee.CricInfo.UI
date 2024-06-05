using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.UI.Controllers
{
    public class MatchScheduleController : Controller
    {
        // GET: MatchSchedule
        [HttpGet]
        public ActionResult MatchSchedule()
        {
            var model = new Cls_MatchSchedule_VO
            {
                MatchDate = DateTime.Now,
                TimeZone = TimeZoneInfo.Local.Id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult MatchSchedule(Cls_MatchSchedule_VO model)
        {
            if (ModelState.IsValid)
            {
                // Process the data
                return RedirectToAction("Success");
            }

            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult DisplayMatchDataInGrid()
        {
            return View();
        }
    }
}
