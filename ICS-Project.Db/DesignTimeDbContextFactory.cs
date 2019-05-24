using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ICS_Project.Db
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IcsDbContext>
    {
        public IcsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IcsDbContext>();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ICSDatabase"));
            return new IcsDbContext(optionsBuilder.Options);
        }
    }
}
