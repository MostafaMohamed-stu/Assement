
using Assement.Database_Connection;
using Microsoft.EntityFrameworkCore;

namespace Assement.Repo.Genric_Repo
{
    public class GenricRepo<T> : IGenricRepo<T> where T : class
    {
        protected readonly AppDbContext db;

        public GenricRepo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task Post(T entity)
        {
           await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            db.Set<T>().Update(entity);
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
        }
    }
}
