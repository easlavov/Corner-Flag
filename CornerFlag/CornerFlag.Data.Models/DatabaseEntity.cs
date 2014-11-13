namespace CornerFlag.Data.Models
{
    using System;

    using CornerFlag.Data.Contracts.Models;

    public abstract class DatabaseEntity : IAuditInfo, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
