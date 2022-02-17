using Microsoft.EntityFrameworkCore;
using SW.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICloneRepository, CloneRepository>();
builder.Services.AddTransient<IDroidRepository, DroidRepository>();
builder.Services.AddTransient<IJediRepository, JediRepository>();
builder.Services.AddTransient<ILegionRepository, LegionRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var swConnectionString = builder.Configuration.GetConnectionString("SWDatabase");

var swContext = new SWContext(swConnectionString);

swContext.Database.Migrate();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
