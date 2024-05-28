using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_BowlingStats_VO
    {
        /// <summary>
        /// Gets or sets the number of maiden overs bowled.
        /// </summary>
        public int Maidens { get; set; }

        /// <summary>
        /// Gets or sets the total runs given up by the bowler.
        /// </summary>
        public int RunsGivenUp { get; set; }

        /// <summary>
        /// Gets or sets the economy rate of the bowler.
        /// </summary>
        public int Economy { get; set; }

        /// <summary>
        /// Gets or sets the number of hat-tricks taken by the bowler.
        /// </summary>
        public int Hattrick { get; set; }
    }
}
