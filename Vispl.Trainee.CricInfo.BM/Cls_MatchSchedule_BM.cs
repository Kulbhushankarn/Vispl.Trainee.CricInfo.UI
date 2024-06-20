using System.Collections.Generic;
using Vispl.Trainee.CricInfo.DL;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.BL
{
    public class MatchScheduleBM
    {
        private readonly Cls_MatchSchedule_DL _matchScheduleDL;

        public MatchScheduleBM(string connectionString)
        {
            _matchScheduleDL = new Cls_MatchSchedule_DL(connectionString);
        }

        public void AddMatchSchedule(Cls_MatchSchedule_VO matchSchedule)
        {
            // Perform any necessary business logic validations here if needed

            // Pass the request to the data access layer
            _matchScheduleDL.AddMatchSchedule(matchSchedule);
        }

        public List<Cls_MatchSchedule_VO> GetAllMatchSchedules()
        {
            // Retrieve match schedules with team and venue names from the data access layer
            return _matchScheduleDL.GetAllMatchSchedulesWithNames();
        }

        public List<KeyValuePair<long, string>> GetTeams()
        {
            return _matchScheduleDL.GetTeams();
        }

        public List<KeyValuePair<long, string>> GetVenues()
        {
            return _matchScheduleDL.GetVenues();
        }
    }
}
