// <copyright file="Program.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SW.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(service => 
    new SWContext(builder.Configuration.GetConnectionString("SWDatabase")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*var swConnectionString = builder.Configuration.GetConnectionString("SWDatabase");

var swContext = new SWContext(swConnectionString);*/

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    app.SeedData();
}
app.Services.GetService<SWContext>().Database.Migrate();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();