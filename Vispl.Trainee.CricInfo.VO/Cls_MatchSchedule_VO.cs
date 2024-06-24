using System;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_MatchSchedule_VO
    {
        public long MatchID { get; set; }
        public long Team1ID { get; set; }
        public long Team2ID { get; set; }
        public DateTime? MatchDate { get; set; }
        public string TimeZone { get; set; }
        public long Venue { get; set; }
        public string MatchFormat { get; set; }

        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public string VenueName { get; set; }
    }
}
