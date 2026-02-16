using Assement.Models;
using Assement.Repo.Genric_Repo;
using Assement.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        ICompetion _competion;
        public CompetitionController(ICompetion _competion)
        {
            this._competion = _competion;
        }
        public async Task<IActionResult> Delete(int id )
        {
            var comp = await _competion.GetById(id);
            if(comp == null) return NotFound();
            _competion.Delete(comp);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            var comp = await _competion.GetCompetion();
            if(comp == null) return NotFound();
            var res = comp.GroupBy(x => x.Location)
                .Select(x => new
                {
                    LocationName = x.Key,
                    Competion = x.Select(x => new
                    {
                        x.Title,
                        x.Date,
                        TotalNumberOfTeam = x.Teams.Count,
                        TotalNumberOfPlayers = x.Teams.Select(t =>new
                        {
                            TeamName = t.Name,
                            PlayerNumber = t.Player.Count(),
                        })
                    }).ToList()
                }).ToList();
            return Ok(comp);
        }
    }
}
