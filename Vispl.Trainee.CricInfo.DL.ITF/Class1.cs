using System.Collections.Generic;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.DL
{
    public interface ICls_Player_DL
    {
        bool AddNewPlayer(Cls_Player_VO player);
        List<Cls_Player_VO> GetAllPlayers();
    }
}