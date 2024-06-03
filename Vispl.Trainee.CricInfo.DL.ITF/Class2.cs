using System.Collections.Generic;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.DL
{
    public interface ICls_CreateTeam_DL
    {
        bool AddTeam(Cls_TeamPlayer_VO team);
        List<Cls_TeamPlayer_VO> GetAllTeams();
        List<string> GetPlayerNames();
    }
}