using System;
using Vispl.Trainee.CricInfo.VO;
using Vispl.Trainee.CricInfo.DL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.BM
{
    public class Cls_Player_BM : ICls_Player_BM
    {
        /// <summary>
        /// DL layer object responsible for data operations related to Player entity
        /// </summary>
        private readonly Cls_Player_DL _dl;

        public Cls_Player_BM(string connectionString)
        {
            _dl = new Cls_Player_DL(connectionString);
        }

        /// <summary>
        /// Handles Validations For new player and sends data to data layer if data is validated
        /// </summary>
        /// <param name="player"> An Object which represents an Player</param>
        /// <returns> True if player get added in DB otherwise false</returns>
        public bool AddNewPlayer(Cls_Player_VO player)
        {
            //Check validations
            try
            {
                return _dl.AddNewPlayer(player);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public List<Cls_Player_VO> DisplayAllPlayers()
        {
            return _dl.GetAllPlayers();
        }
    }
}
