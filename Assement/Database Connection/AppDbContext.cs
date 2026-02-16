using Assement.Models;
using Microsoft.EntityFrameworkCore;

namespace Assement.Database_Connection
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Coach> coaches { get; set; }
        public DbSet<Competion> competions { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Team> teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasMany(x => x.Competions)
                .WithMany(x => x.Teams);
            modelBuilder.Entity<Coach>().HasData(
                new Coach { Id = 1, Name ="Marwan" ,Specailiztion="Football",ExperenceYear = 3,},
                new Coach { Id = 2, Name = "Ibrahim" ,Specailiztion = "Basketball",ExperenceYear = 2},
                new Coach { Id = 3, Name = "Hussien", Specailiztion = "Basketball", ExperenceYear = 2 },
                new Coach { Id = 4, Name = "Saif", Specailiztion = "Football", ExperenceYear = 2 }
                );
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, City = "Cairo" ,Name = "AlAhly",CoachId = 1},
                new Team { Id = 2, City = "Paris", Name = "Paris",CoachId = 2 },
                new Team { Id = 3, City = "Cairo", Name = "Pyramids" , CoachId = 3 }

                );
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Salah" ,age = 22,TeamId = 1 ,Postion = "Goalkeeper"},
                new Player { Id = 2,Name = "Moody Amin" , age = 32,TeamId =1 ,Postion = "Goalkeeper" },
                new Player { Id = 3, Name = "Messi", age = 32, TeamId = 2 ,Postion = "Striker"},
                new Player { Id = 4, Name = "Popa", age = 32, TeamId = 3 , Postion = "Diffencer"}
                );
            modelBuilder.Entity<Competion>().HasData(
                new Competion { Id= 1,Date = new DateTime(2025,8,9),Location = "Mansoura",Title = "Chimp"},
                 new Competion { Id = 2, Date = new DateTime(2025,1,2), Location = "Paris", Title = "Chimp" },
                  new Competion { Id = 3, Date = new DateTime(2025,4,8), Location = "Soudi Arabia", Title = "Chimp" },
                   new Competion { Id = 4, Date = new DateTime(2025,11,7), Location = "Mansoura", Title = "Chimp" }
                );
        }
    }
}
