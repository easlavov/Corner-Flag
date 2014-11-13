﻿namespace CornerFlag.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CornerFlag.Data.Contracts.Models;

    public abstract class DatabaseEntity : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
