using System.Security.Cryptography.Xml;
using Assement.Models;
using Assement.Repo.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayer _player;
        public PlayerController(IPlayer _player)
        {
            this._player = _player;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string postion)
        {
            try
            {
                var player = await _player.GetById(id);
                if (player == null) return BadRequest("Error : Invalid Id");
                if (postion == null) return BadRequest("Error : BadRequest");
                player.Postion = postion;
                _player.Update(player);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var player = await _player.GetPlayer();
            if (player == null || !player.Any()) return NotFound("Error : Not Found");
            var result = player.GroupBy(x => x.Team)
                .Select(x => new
                {
                    TeamName = x.Key.Name,
                    Player = x.Select(p => new
                    {
                        PlayerName = p.Name,
                        age = p.age,
                    }).First(),
                });
            return Ok(player);
        }
    }

}
