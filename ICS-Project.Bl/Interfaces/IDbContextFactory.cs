using ICS_Project.Db;

namespace ICS_Project.Bl.Interfaces
{
    public interface IDbContextFactory
    {
        IcsDbContext CreateDbContext();
    }
}
