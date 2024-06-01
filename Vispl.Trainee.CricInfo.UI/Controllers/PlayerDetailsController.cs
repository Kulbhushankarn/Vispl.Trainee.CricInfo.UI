using Vispl.Trainee.CricInfo.BM;
using Vispl.Trainee.CricInfo.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vispl.Trainee.CricInfo.UI.Controllers
{
    public class PlayerDetailsController : Controller
    {
        private ICls_Player_BM _playerBM;

        public PlayerDetailsController()
        {

            _playerBM = new Cls_Player_BM(ConfigurationManager.ConnectionStrings["Dev"].ConnectionString);
        }
        // GET: Admin/PlayerDetails
        public ActionResult NewPlayer()
        {
            Cls_Player_VO player = new Cls_Player_VO();
            return View(player);
        }
        
        [HttpPost]
        public ActionResult NewPlayer(Cls_Player_VO player)
        {
            try
            {
                if (_playerBM.AddNewPlayer(player))
                {
                    return RedirectToAction("DisplayPlayersDataInGrid");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add player.");
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "An error occurred while adding the player.");
                // Log the exception or handle it appropriately
            }

            // If execution reaches here, there was an error, so return to the same view with model errors
            return View(player);
        }


        public ActionResult DisplayPlayersDataInGrid()
        {
            return View(_playerBM.DisplayAllPlayers());
        }

    }
}