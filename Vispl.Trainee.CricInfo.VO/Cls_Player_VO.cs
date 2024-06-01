using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_Player_VO
    {
        [Key]
        public long PlayerID { get; set; }

        /// <summary>
        /// Gets or sets the jersey number of the player.
        /// </summary>
        [Display(Name = "Jersey Number")]
        public int JerseyNo { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [Display(Name = "Player Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the player.
        /// </summary>
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the age of the player.
        /// </summary>
        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        /// <summary>
        /// Gets or sets the birth place of the player.
        /// </summary>
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }

        /// <summary>
        /// Gets or sets the player type.
        /// </summary>
        [Display(Name = "Player Type")]
        public string PlayerType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is a captain.
        /// </summary>
        [Display(Name = "Is Captain")]
        public bool IsCaptain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is a substitute.
        /// </summary>
        [Display(Name = "Is Substitute")]
        public bool IsSubstitute { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the player.
        /// </summary>
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the team the player is currently playing for.
        /// </summary>
        [Display(Name = "Team")]
        public string Team { get; set; }

        /// <summary>
        /// Gets or sets the number of matches played by the player.
        /// </summary>
        [Display(Name = "Matches Played")]
        public int MatchesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of runs scored by the player.
        /// </summary>
        [Display(Name = "Runs Scored")]
        public int RunsScored { get; set; }

        /// <summary>
        /// Gets or sets the number of wickets taken by the player.
        /// </summary>
        [Display(Name = "Wickets Taken")]
        public int WicketsTaken { get; set; }

        /// <summary>
        /// Gets or sets the batting average of the player.
        /// </summary>
        [Display(Name = "Batting Average")]
        public double BattingAverage { get; set; }

        /// <summary>
        /// Gets or sets the bowling average of the player.
        /// </summary>
        [Display(Name = "Bowling Average")]
        public double BowlingAverage { get; set; }

        /// <summary>
        /// Gets or sets the number of centuries scored by the player.
        /// </summary>
        [Display(Name = "Centuries")]
        public int Centuries { get; set; }

        /// <summary>
        /// Gets or sets the number of half-centuries scored by the player.
        /// </summary>
        [Display(Name = "Half-Centuries")]
        public int HalfCenturies { get; set; }

        /// <summary>
        /// Gets or sets the debut date of the player.
        /// </summary>
        [Display(Name = "Debut Date")]
        [DataType(DataType.Date)]
        public DateTime DebutDate { get; set; }

        /// <summary>
        /// Gets or sets the ICC ranking of the player.
        /// </summary>
        [Display(Name = "ICC Ranking")]
        public int ICCRanking { get; set; }

        /// <summary>
        /// Gets or sets the URL of the player's profile picture.
        /// </summary>
        [Display(Name = "Profile Picture URL")]
        public string Picture { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cls_Player_VO"/> class.
        /// </summary>
        public Cls_Player_VO()
        {
            // Initialize other statistics if necessary
        }
    }
}
