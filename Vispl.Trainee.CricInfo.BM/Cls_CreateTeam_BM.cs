using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Vispl.Trainee.CricInfo.VO;
using Vispl.Trainee.CricInfo.DL;

namespace Vispl.Trainee.CricInfo.BM
{
    public class Cls_CreateTeam_BM : ICls_CreateTeam_BM
    {
        private readonly Cls_CreateTeam_DL _dl;

        public Cls_CreateTeam_BM(string connectionString)
        {
            _dl = new Cls_CreateTeam_DL(connectionString);
        }

        public bool AddTeam(Cls_TeamPlayer_VO team)
        {
            try
            {
                return _dl.AddTeam(team);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Cls_TeamPlayer_VO> DisplayAllTeams()
        {
            return _dl.GetAllTeams();
        }

        public List<string> GetPlayerNames()
        {
            return _dl.GetPlayerNames();
        }
    }
}
