using System;
using Vispl.Trainee.CricInfo.DL;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.BM
{
    public class Cls_Toss_BM
    {
        private readonly Cls_Toss_DL _dl;

        public Cls_Toss_BM(string connectionString)
        {
            _dl = new Cls_Toss_DL(connectionString);
        }

        public bool AddToss(Cls_Toss_VO toss)
        {
            return _dl.AddToss(toss);
        }
    }
}
