using Assement.Database_Connection;
using Assement.Models;
using Assement.Repo.Genric_Repo;
using Assement.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Assement.Repo.Immplemntion
{
    public class PlayerRepo : GenricRepo<Player>, IPlayer
    {
        public PlayerRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Player>> GetPlayer()
        {
            return await db.players.Include(t => t.Team).Where(x => x.Team !=null).OrderBy(x => x.age).ToListAsync();
        }
    }
}
