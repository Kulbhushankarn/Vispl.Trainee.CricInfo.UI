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
        public ActionResult NewPlayer(Cls_Player_VO player, FormCollection frm)
        {
            try
            {
                _playerBM.AddNewPlayer(player);
            }
            catch (SqlException ex)
            {
                return View("Error", ex);
            }

            return View();
        }

        public ActionResult DisplayPlayersDataInGrid()
        {
            return View(_playerBM.DisplayAllPlayers());
        }

    }
}