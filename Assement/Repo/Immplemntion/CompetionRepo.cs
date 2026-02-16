using Assement.Database_Connection;
using Assement.Models;
using Assement.Repo.Genric_Repo;
using Assement.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Assement.Repo.Immplemntion
{
    public class CompetionRepo : GenricRepo<Competion>, ICompetion
    {
        public CompetionRepo(AppDbContext db) : base(db)
        {
        }

        public async Task<List<Competion>> GetCompetion()
        {
            return await db.competions.Include(t => t.Teams).ThenInclude(p => p.Player).Where(x => x.Teams.Count>0).ToListAsync();
        }
    }
}
