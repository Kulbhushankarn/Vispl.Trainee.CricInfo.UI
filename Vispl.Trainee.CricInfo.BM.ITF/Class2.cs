using System.Collections.Generic;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.BM
{
    public interface ICls_CreateTeam_BM
    {
        bool AddTeam(Cls_TeamPlayer_VO team);
        List<Cls_TeamPlayer_VO> DisplayAllTeams();
        List<string> GetPlayerNames();
    }
}