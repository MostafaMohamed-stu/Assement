using Assement.Models;
using Assement.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        readonly ICoach _coach;

        public CoachController(ICoach coach)
        {
            _coach = coach;
        }
        [HttpGet("coches")]
        public async Task<IActionResult> Get()
        {
                var coach = await _coach.GetCoach();
                if (coach == null || !coach.Any()) return NotFound("Error :Not Found");
                var result = coach.GroupBy(x => x.Player).
                           Select(x => new
                           {
                               Name = x.Key,
                               Coache = x.Select(c => new
                               {
                                   CoachName = c.Name,
                                   CoachExp = c.Coach,
                                   Coachspecailiztio = c.Coach,
                                   team = new
                                   {
                                       TeamName = c.Coach.Name,
                                       TeamCity = c.Coach.Team,
                                   }

                               }),

                           });
                return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
                var coach = await _coach.GetCoach(id);
                if (coach == null) return NotFound("Error : Not Found");
                var result = new
                {
                    CoachName = coach.Name,
                    Specailiztion = coach.Name,
                    ExperenceYear = coach.CoachId,
                    Team = new
                    {
                        TeamName = coach.Coach,
                        TeamCity = coach.Coach,
                    },
                    TotalNumberOfPlayers = coach.Player.Count(),
                };
                return Ok(result);
        }
    }
}
