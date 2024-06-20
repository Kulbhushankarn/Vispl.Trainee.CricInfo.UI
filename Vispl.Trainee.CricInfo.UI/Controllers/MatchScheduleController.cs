using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.BL;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.UI.Controllers
{
    public class MatchScheduleController : Controller
    {
        private readonly MatchScheduleBM _matchScheduleBM;

        public MatchScheduleController()
        {
            _matchScheduleBM = new MatchScheduleBM(ConfigurationManager.ConnectionStrings["Dev"].ConnectionString);
        }

        // GET: MatchSchedule
        [HttpGet]
        public ActionResult MatchSchedule()
        {
            var model = new Cls_MatchSchedule_VO
            {
                MatchDate = DateTime.Now,
                TimeZone = TimeZoneInfo.Local.Id
            };

            ViewBag.Teams = _matchScheduleBM.GetTeams();
            ViewBag.Venues = _matchScheduleBM.GetVenues();

            return View(model);
        }

        [HttpPost]
        public ActionResult MatchSchedule(Cls_MatchSchedule_VO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _matchScheduleBM.AddMatchSchedule(model);
                    return View(model);
                }
                catch (Exception ex)
                {
                    // Handle exceptions and show error message to the user
                    ModelState.AddModelError("", "Error adding match schedule: " + ex.Message);
                }
            }

            ViewBag.Teams = _matchScheduleBM.GetTeams();
            ViewBag.Venues = _matchScheduleBM.GetVenues();

            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult DisplayMatchDataInGrid()
        {
            List<Cls_MatchSchedule_VO> matchSchedules;
            try
            {
                matchSchedules = _matchScheduleBM.GetAllMatchSchedules();
            }
            catch (Exception ex)
            {
                // Handle exceptions and show error message to the user
                matchSchedules = new List<Cls_MatchSchedule_VO>();
                ModelState.AddModelError("", "Error retrieving match schedules: " + ex.Message);
            }

            return View(matchSchedules);
        }
    }
}
