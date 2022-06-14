// See https://aka.ms/new-console-template for more information

using HomeLab.EF.Infra;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var sw = Stopwatch.StartNew();
Console.WriteLine("Deploying database...");
var dbContext = new EfContextFactory().CreateDbContext(args);
dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(30));
dbContext.Database.Migrate();
Console.WriteLine($"Deployment done in {sw.Elapsed}");