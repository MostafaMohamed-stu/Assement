using Assement.Dtos;
using Assement.Models;
using Assement.Repo.Genric_Repo;
using Assement.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        readonly ITeam _team;
        readonly IGenricRepo<Coach> _coach;
        public TeamController(ITeam team, IGenricRepo<Coach> _coach)
        {
            _team = team;
            this._coach = _coach;
        }
        [HttpPost]
        public async Task<IActionResult> Add(TeamCreateDto dto)
        {
            try
            {
                if (dto == null) return BadRequest("Error :Badrequest");
                if (dto.CoachId == null || dto.Name == null) return BadRequest("Error :Badrequest");
                var coach = await _coach.GetById(dto.CoachId);
                if (coach == null) return BadRequest("Error :BadReques");

                var Team = new Team
                {
                    Name = dto.Name,
                    City = dto.City,
                    Coach = coach,

                };
                await _team.Post(Team);
                return Ok(Team);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _team.GetTeams();
            if (teams == null ||!teams.Any()) return NotFound("Error Not Found");
            var result = teams.Select(x => new
            {
                x.Name,
                x.City,
                TotalNumberOfPlayers = x.Player.Count,
                TotalCompetion = x.Competions.Count()
            }).OrderByDescending(x => x.TotalNumberOfPlayers);
            return Ok(result);
        }
    }
}
