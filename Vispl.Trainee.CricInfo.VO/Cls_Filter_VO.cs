using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.VO
{
    public class Cls_Filter_VO
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public List<Cls_MatchSchedule_VO> FilteredMatchSchedules { get; set; }
    }
}
