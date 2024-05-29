using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_MatchSchedule_VO
    {
        [Required]
        public string Team1 { get; set; }

        [Required]
        public string Team2 { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public string TimeZone { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        public string MatchFormat { get; set; }
    }
}
