using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_BattingStats_VO
    {
        /// <summary>
        /// Gets or sets the number of matches played.
        /// </summary>
        public int MatchesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of innings played.
        /// </summary>
        public int Innings { get; set; }

        /// <summary>
        /// Gets or sets the total runs scored.
        /// </summary>
        public int Runs { get; set; }

        /// <summary>
        /// Gets or sets the highest score in a single innings.
        /// </summary>
        public int HighestScore { get; set; }

        /// <summary>
        /// Gets or sets the batting average.
        /// </summary>
        public int Average { get; set; }

        /// <summary>
        /// Gets or sets the number of fifties scored.
        /// </summary>
        public int Fifties { get; set; }

        /// <summary>
        /// Gets or sets the number of centuries scored.
        /// </summary>
        public int Centuries { get; set; }

        /// <summary>
        /// Gets or sets the number of fours scored.
        /// </summary>
        public int Fours { get; set; }

        /// <summary>
        /// Gets or sets the number of sixes scored.
        /// </summary>
        public int Sixes { get; set; }

        /// <summary>
        /// Gets or sets the strike rate.
        /// </summary>
        public int StrikeRate { get; set; }
    }
}