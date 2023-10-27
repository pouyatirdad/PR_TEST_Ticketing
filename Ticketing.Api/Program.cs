using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Ticketing.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connString ="DataSource=:memory:";
var conn =new SqliteConnection(connString);
conn.Open();

builder.Services.AddDbContext<MyDbContext>(o=>o.UseSqlite(conn));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
