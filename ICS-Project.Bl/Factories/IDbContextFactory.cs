using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Db;

namespace ICS_Project.Bl.Factories
{
    public interface IDbContextFactory
    {
        IcsDbContext CreateDbContext();
    }
}
