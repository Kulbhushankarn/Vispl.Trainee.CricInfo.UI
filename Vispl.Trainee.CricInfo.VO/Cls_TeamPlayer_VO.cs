using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{

        public class Cls_TeamPlayer_VO
        {
            public string TeamName { get; set; }
            public string TeamShortName { get; set; }
            public List<long> TeamPlayer { get; set; }
            public long TeamCaptain { get; set; }
            public long TeamWicketKeeper { get; set; }
            public long TeamViceCaptain { get; set; }

        }
}
