using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ICS_Project.Bl.Factories
{
    public class DbContextFactory:IDbContextFactory
    {
        public IcsDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<IcsDbContext>();
            optionsBuilder.UseLazyLoadingProxies();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ICSDatabase"));

            return new IcsDbContext(optionsBuilder.Options);
        }
    }
}
