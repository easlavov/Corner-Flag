namespace CornerFlag.Data.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Season : DatabaseEntity
    {
        public Season()
        {
            this.Rounds = new HashSet<Round>();
            this.ParticipatingClubs = new HashSet<Club>();
        }

        [Range(1872, 3000)]
        public int StartYear { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }

        public virtual ICollection<Club> ParticipatingClubs { get; set; }
    }
}
