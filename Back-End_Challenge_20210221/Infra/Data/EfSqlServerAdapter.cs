﻿using Back_End_Challenge_20210221.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End_Challenge_20210221.Infra.Data;

public class EfSqlServerAdapter : DbContext
{
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Launch> Launchers { get; set; }
    public DbSet<LaunchServiceProvider> LaunchServiceProviders { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Orbit> Orbits { get; set; }
    public DbSet<Pad> Pads { get; set; }
    public DbSet<Domain.Models.Program> Programs { get; set; }
    public DbSet<Rocket> Rockets { get; set; }
    public DbSet<Status> Status { get; set; }

    public EfSqlServerAdapter(DbContextOptions options) : base(options)
    {
        
    }
}
