using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_Toss_VO
    {
        public long TossID { get; set; }
        public long MatchID { get; set; }
        public Cls_MatchSchedule_VO Match { get; set; }
        public long TossWonByWhichTeamID { get; set; }
        public E_TossDecision TossDecision { get; set; }
    }

    public enum E_TossDecision
    {
        Bat,
        Bowl
    }
}

