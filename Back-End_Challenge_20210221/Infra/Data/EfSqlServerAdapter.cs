using Back_End_Challenge_20210221.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End_Challenge_20210221.Infra.Data
{
    public class EfSqlServerAdapter : DbContext
    {
        public DbSet<Launch> Launchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.0.5,1433;Database=BackEndChallengeDb;User Id=SA;Password=BackEndChallenge@20210221;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
    }
}
