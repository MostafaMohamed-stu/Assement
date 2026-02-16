using Assement.Database_Connection;
using Assement.Repo.Genric_Repo;
using Assement.Repo.Immplemntion;
using Assement.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddScoped(typeof(IGenricRepo<>), typeof(GenricRepo<>));
builder.Services.AddScoped<ICoach, CoachRepo>();
builder.Services.AddScoped<ITeam, TeamRepo>();
builder.Services.AddScoped<IPlayer, PlayerRepo>();
builder.Services.AddTransient<ICompetion, CompetionRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
