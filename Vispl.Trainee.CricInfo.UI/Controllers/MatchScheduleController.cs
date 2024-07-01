using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.BM;
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

        private void PopulateViewBags()
        {
            ViewBag.Teams = _matchScheduleBM.GetTeams();
            ViewBag.Venues = _matchScheduleBM.GetVenues();
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

            PopulateViewBags();

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
                    return RedirectToAction("DisplayMatchDataInGrid");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error adding match schedule: " + ex.Message);
                    // Log exception here
                }
            }

            PopulateViewBags();
            return View(model);
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
                matchSchedules = new List<Cls_MatchSchedule_VO>();
                ModelState.AddModelError("", "Error retrieving match schedules: " + ex.Message);
                // Log exception here
            }

            return View(matchSchedules);
        }

        [HttpGet]
        public ActionResult Filter()
        {
            var model = new Cls_Filter_VO
            {
                FromDate = DateTime.Now.AddMonths(-1),
                ToDate = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Filter(Cls_Filter_VO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var matchSchedules = _matchScheduleBM.GetAllMatchSchedules();
                    model.FilteredMatchSchedules = matchSchedules.FindAll(m =>
                        (!model.FromDate.HasValue || m.MatchDate >= model.FromDate.Value) &&
                        (!model.ToDate.HasValue || m.MatchDate <= model.ToDate.Value));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error retrieving match schedules: " + ex.Message);
                }
            }

            return View(model);
        }

        public ActionResult StartMatch(long matchId)
        {
            var matchDetails = _matchScheduleBM.GetMatchDetails(matchId);

            if (matchDetails == null)
            {
                return HttpNotFound(); // Handle if match details are not found
            }

            return View(matchDetails); // Assuming you have a view named StartMatch to display match details
        }



        public ActionResult HandleToss(long matchId, string tossResult)
        {
            return RedirectToAction("MatchDetails", new { matchId });
        }

    }
}
