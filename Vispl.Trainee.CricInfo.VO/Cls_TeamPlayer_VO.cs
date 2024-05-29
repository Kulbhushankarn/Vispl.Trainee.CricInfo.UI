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
            public List<string> TeamPlayers { get; set; }
            public string TeamCaptain { get; set; }
            public string TeamWicketKeeper { get; set; }
            public string TeamViceCaptain { get; set; }

        }
}
