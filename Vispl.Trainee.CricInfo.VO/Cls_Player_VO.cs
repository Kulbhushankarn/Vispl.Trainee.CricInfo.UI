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
        /// Gets or sets the name of the player.
        /// </summary>
        [Display(Name = "Player Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the player.
        /// </summary>
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the player.
        /// </summary>
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the role of the player.
        /// </summary>
        [Display(Name = "Player Role")]
        public PlayerType Role { get; set; }

        /// <summary>
        /// Gets or sets the batting style of the player.
        /// </summary>
        [Display(Name = "Batting Style")]
        public string BattingStyle { get; set; }

        /// <summary>
        /// Gets or sets the bowling style of the player.
        /// </summary>
        [Display(Name = "Bowling Style")]
        public string BowlingStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is an all-rounder.
        /// </summary>
        [Display(Name = "Is All-Rounder")]
        public bool isAllRounder { get; set; }

        /// <summary>
        /// Gets or sets the URL of the player's profile picture.
        /// </summary>
        [Display(Name = "Profile Picture URL")]
        public string PicURL { get; set; }

        /// <summary>
        /// Gets or sets the team the player is currently playing for.
        /// </summary>
        [Display(Name = "Team Playing For")]
        public string TeamPlayingFor { get; set; }

        /// <summary>
        /// Gets or sets the batting statistics of the player.
        /// </summary>
        public Cls_BattingStats_VO BattingStatistics { get; set; }

        /// <summary>
        /// Gets or sets the bowling statistics of the player.
        /// </summary>
        public Cls_BowlingStats_VO BowlingStatistics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cls_Player_VO"/> class.
        /// </summary>
        public Cls_Player_VO()
        {
            BattingStatistics = new Cls_BattingStats_VO();
            if (BowlingStyle != null)
            {
                BowlingStatistics = new Cls_BowlingStats_VO();
            }
        }

    }

    public enum Nationality
    {
        India,
        England,
        SouthAfrica,
        Australia,
        Bangladesh,
        Pakistan,
    }

    /// <summary>
    /// Represents the role of a cricket player.
    /// </summary>
    public enum PlayerType
    {
        ordinaryPlayer,
        wicketKeeper,
        Captain,
        ViceCaptain,
    }

    /// <summary>
    /// Represents the batting style of a cricket player.
    /// </summary>
    public enum BattingStyle
    {
        RightHanded,
        LeftHanded,
        Aggressive,
        Defensive,
    }

    /// <summary>
    /// Represents the bowling style of a cricket player.
    /// </summary>
    public enum BowlingStyle
    {
        Fast,
        MediumPace,
        Spin,
        LeftArmFast,
        LeftArmMediumPace,
        LeftArmSpin,
        LegSpin,
        OffSpin
    }
}
