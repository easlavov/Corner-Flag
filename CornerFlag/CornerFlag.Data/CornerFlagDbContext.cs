namespace CornerFlag.Data
{
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    using CornerFlag.Data.Models;
    using CornerFlag.Data.Migrations;
    using System;
    using CornerFlag.Data.Contracts.Models;
    using CornerFlag.Data.Models.Entities;
    using CornerFlag.Data.Models.People;

    public class CornerFlagDbContext : IdentityDbContext<ApplicationUser> , ICornerFlagDbContext
    {
        public CornerFlagDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CornerFlagDbContext, Configuration>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<CornerFlagDbContext>());
        }

        public static CornerFlagDbContext Create()
        {
            return new CornerFlagDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            //this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        //private void ApplyDeletableEntityRules()
        //{
        //    // Approach via @julielerman: http://bit.ly/123661P
        //    foreach (
        //        var entry in
        //            this.ChangeTracker.Entries()
        //                .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
        //    {
        //        var entity = (IDeletableEntity)entry.Entity;

        //        entity.DeletedOn = DateTime.Now;
        //        entity.IsDeleted = true;
        //        entry.State = EntityState.Modified;
        //    }
        //}


        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Stadium> Stadiums { get; set; }

        public virtual IDbSet<Match> Games { get; set; }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Club> Clubs { get; set; }

        public virtual IDbSet<Competition> Competitions { get; set; }

        public virtual IDbSet<Round> Rounds { get; set; }

        public virtual IDbSet<Season> Seasons { get; set; }

        public new DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
