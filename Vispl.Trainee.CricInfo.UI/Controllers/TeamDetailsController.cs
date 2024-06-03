using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.VO;
using Vispl.Trainee.CricInfo.BM;
using System.Configuration;
using System.Data.SqlClient;

namespace Vispl.Trainee.CricInfo.UI.Controllers
{
    public class TeamDetailsController : Controller
    {
        private readonly Cls_CreateTeam_BM _bm;

        public TeamDetailsController()
        {
            _bm = new Cls_CreateTeam_BM(ConfigurationManager.ConnectionStrings["Dev"].ConnectionString);
        }

        public ActionResult TeamDetails()
        {
            ViewBag.Players = _bm.GetPlayerNames();
            Cls_TeamPlayer_VO team = new Cls_TeamPlayer_VO();
            return View(team);
        }

        [HttpPost]
        public ActionResult TeamDetails(Cls_TeamPlayer_VO team)
        {
            try
            {
                if (_bm.AddTeam(team))
                {
                    return RedirectToAction("DisplayTeamDetailsInGrid");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add team.");
                }
            }
            catch (SqlException)
            {
                ModelState.AddModelError("", "An error occurred while adding the team.");
            }

            ViewBag.Players = _bm.GetPlayerNames();
            return View(team);
        }

        public ActionResult DisplayTeamDetailsInGrid()
        {
            return View(_bm.DisplayAllTeams());
        }
    }
}
