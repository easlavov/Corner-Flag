namespace CornerFlag.Data.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CornerFlag.Common;
    using CornerFlag.Data.Models.People;

    public class Club : NamedDatabaseEntry
    {
        public Club()
        {
            this.Competitions = new HashSet<Competition>();
            this.Teams = new HashSet<Team>();
            this.Games = new HashSet<Match>();
        }

        [Required]
        [DateAttribute(-100, 0)]
        public DateTime DateFounded { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Match> Games { get; set; }

        public virtual ICollection<Season> Seasons { get; set; }
    }
}
