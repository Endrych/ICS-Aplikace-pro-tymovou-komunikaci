using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Factories;
using ICS_Project.Db;
using Microsoft.EntityFrameworkCore;

namespace ICS_Project.Tests
{
    public class InMemoryDbContextFactory:IDbContextFactory
    {
        public IcsDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<IcsDbContext>()
                .UseInMemoryDatabase(databaseName: "IcsInMemory")
                .Options;

            return new IcsDbContext(options);
        }
    }
}
