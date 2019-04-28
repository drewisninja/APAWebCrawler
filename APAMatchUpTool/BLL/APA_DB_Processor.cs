using APAMatchUpTool.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APAMatchUpTool.BLL
{
    public class APA_DB_Processor
    {
        ITeamsRepository _ITeamRepo;

        public APA_DB_Processor(ITeamsRepository _repo)
        {
            this._ITeamRepo = _repo;
        }

        public async Task<List<SelectListItem>> GetTeams_SelectListItem()
        {

            List<SelectListItem> selectItem = new List<SelectListItem>();
            List<Models.Teams> teamList = await _ITeamRepo.GetTeams();

            foreach (Models.Teams item in teamList)
            {
                selectItem.Add(new SelectListItem { Text = item.TeamName, Value = item.TeamID });
            }

            return selectItem;
        }
    }
}
