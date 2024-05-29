using System.Collections.Generic;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.BM
{
    public interface ICls_Player_BM
    {
        bool AddNewPlayer(Cls_Player_VO player);
        List<Cls_Player_VO> DisplayAllPlayers();
    }
}