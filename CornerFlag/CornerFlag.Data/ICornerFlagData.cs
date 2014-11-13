namespace CornerFlag.Data
{
    using CornerFlag.Data.Contracts.Repository;
    using CornerFlag.Data.Models;
    using CornerFlag.Data.Models.Entities;
    using CornerFlag.Data.Models.People;

    public interface ICornerFlagData
    {
        ICornerFlagDbContext Context { get; }

        IDeletableEntityRepository<Country> Countries { get; }

        IDeletableEntityRepository<Stadium> Stadiums { get; }

        IDeletableEntityRepository<Match> Games { get; }

        IDeletableEntityRepository<Player> Players { get; }

        IDeletableEntityRepository<Team> Teams { get; }

        IDeletableEntityRepository<Club> Clubs { get; }

        IDeletableEntityRepository<Competition> Competitions { get; }

        IDeletableEntityRepository<Round> Rounds { get; }

        IDeletableEntityRepository<Season> Seasons { get; }
        
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
