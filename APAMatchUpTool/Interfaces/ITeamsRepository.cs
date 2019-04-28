using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APAMatchUpTool.Interfaces
{
    public interface ITeamsRepository
    {
        Task<List<Models.Teams>> GetTeams();
    }
}
