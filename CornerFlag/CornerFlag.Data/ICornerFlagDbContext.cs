namespace CornerFlag.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using CornerFlag.Data.Models;
    using CornerFlag.Data.Models.Entities;
    using CornerFlag.Data.Models.People;

    public interface ICornerFlagDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Country> Countries { get; }

        IDbSet<Stadium> Stadiums { get; }

        IDbSet<Match> Games { get; }

        IDbSet<Player> Players { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<Club> Clubs { get; }

        IDbSet<Competition> Competitions { get; }

        IDbSet<Round> Rounds { get; }

        IDbSet<Season> Seasons { get; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
