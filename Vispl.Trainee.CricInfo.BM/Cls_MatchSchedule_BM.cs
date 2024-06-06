using System;
using System.Collections.Generic;
using Vispl.Trainee.CricInfo.DL;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.BM
{
    public class MatchScheduleBM
    {
        private readonly Cls_CreateTeam_DL _createTeamDL;
        private readonly Cls_MatchSchedule_DL _matchScheduleDL;

        public MatchScheduleBM(string connectionString)
        {
            _createTeamDL = new Cls_CreateTeam_DL(connectionString);
            _matchScheduleDL = new Cls_MatchSchedule_DL(connectionString);
        }

        public void AddMatchSchedule(Cls_MatchSchedule_VO matchSchedule)
        {
            try
            {
                // Add match schedule to the database
                _matchScheduleDL.AddMatchSchedule(matchSchedule);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding match schedule: " + ex.Message);
            }
        }

        public List<Cls_MatchSchedule_VO> GetAllMatchSchedules()
        {
            try
            {
                // Retrieve all match schedules from the database
                return _matchScheduleDL.GetAllMatchSchedules();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving match schedules: " + ex.Message);
            }
        }

        public List<Cls_TeamPlayer_VO> GetAllTeams()
        {
            try
            {
                // Retrieve all teams from the database
                return _createTeamDL.GetAllTeams();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving teams: " + ex.Message);
            }
        }
    }
}
