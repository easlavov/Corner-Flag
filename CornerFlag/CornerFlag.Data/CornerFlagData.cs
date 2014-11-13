namespace CornerFlag.Data
{
    using System;
    using System.Collections.Generic;

    using CornerFlag.Data.Contracts.Models;
    using CornerFlag.Data.Contracts.Repository;
    using CornerFlag.Data.Models;
    using CornerFlag.Data.Models.Entities;
    using CornerFlag.Data.Models.People;

    public class CornerFlagData : ICornerFlagData
    {
        private ICornerFlagDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public CornerFlagData(ICornerFlagDbContext context)
        {
            this.context = context;
        }

        public ICornerFlagDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IDeletableEntityRepository<Country> Countries
        {
            get { return this.GetDeletableEntityRepository<Country>(); }
        }

        public IDeletableEntityRepository<Stadium> Stadiums
        {
            get { return this.GetDeletableEntityRepository<Stadium>(); }
        }

        public IDeletableEntityRepository<Match> Games
        {
            get { return this.GetDeletableEntityRepository<Match>(); }
        }

        public IDeletableEntityRepository<Player> Players
        {
            get { return this.GetDeletableEntityRepository<Player>(); }
        }

        public IDeletableEntityRepository<Team> Teams
        {
            get { return this.GetDeletableEntityRepository<Team>(); }
        }

        public IDeletableEntityRepository<Club> Clubs
        {
            get { return this.GetDeletableEntityRepository<Club>(); }
        }

        public IDeletableEntityRepository<Competition> Competitions
        {
            get { return this.GetDeletableEntityRepository<Competition>(); }
        }

        public IDeletableEntityRepository<Round> Rounds
        {
            get { return this.GetDeletableEntityRepository<Round>(); }
        }

        public IDeletableEntityRepository<Season> Seasons
        {
            get { return this.GetDeletableEntityRepository<Season>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
