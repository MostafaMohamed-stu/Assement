using Assement.Database_Connection;
using Assement.Models;
using Assement.Repo.Genric_Repo;
using Assement.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Assement.Repo.Immplemntion
{
    public class TeamRepo : GenricRepo<Team>, ITeam
    {
        public TeamRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Team>> GetTeams()
        {
           return await db.teams.Include(x => x.Competions).Include(p => p.Player)
                .Where(x => x.Competions.Count == 0).ToListAsync();
        }
    }
}
