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
            this.Team = new HashSet<Player>();
            this.Games = new HashSet<Match>();
        }

        [Required]
        [DateAttribute(-100, 0)]
        public DateTime DateFounded { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }

        public virtual ICollection<Player> Team { get; set; }

        public virtual ICollection<Match> Games { get; set; }
    }
}
