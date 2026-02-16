using Assement.Database_Connection;
using Assement.Models;
using Assement.Repo.Genric_Repo;
using Assement.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Assement.Repo.Immplemntion
{
    public class CoachRepo : GenricRepo<Team>, ICoach
    {
        public CoachRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Team>> GetCoach()
        {
            return await db.teams.Include(x => x.Name).Where(x => x.Coach != null).ToListAsync();
        }

        public async Task<Team> GetCoach(int id)
        {
            return await db.teams.Include(x => x.Coach).ThenInclude(p => p.Team).Where(x => x.Player != null).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
