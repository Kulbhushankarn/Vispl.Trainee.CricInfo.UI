using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.UI.Controllers
{
    public class TeamDetailsController : Controller
    {
        // GET: TeamDetails
        public ActionResult TeamDetails()
        {
            ViewBag.Players = new List<string> { "Player1", "Player2", "Player3", "Player4", "Player5" };
            return View();
        }

        [HttpPost]
        public ActionResult TeamDetails(Cls_TeamPlayer_VO team)
        {
            if (ModelState.IsValid)
            {
                // Save the team data or perform necessary actions
                return RedirectToAction("Index"); // Redirect to some other action
            }
            ViewBag.Players = new List<string> { "Player1", "Player2", "Player3", "Player4", "Player5" };
            return View(team);
        }
    }
}