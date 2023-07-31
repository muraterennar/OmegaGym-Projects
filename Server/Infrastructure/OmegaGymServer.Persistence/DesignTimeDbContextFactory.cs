using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OmegaGymEfDbContext>
{

    public OmegaGymEfDbContext CreateDbContext(string[] args)
    {

        // Get connection string
        var optionsBuilder = new DbContextOptionsBuilder<OmegaGymEfDbContext>();
        optionsBuilder.UseSqlServer(ConnectionConfiguration.ConnectionString);
        return new OmegaGymEfDbContext(optionsBuilder.Options);
    }
}

