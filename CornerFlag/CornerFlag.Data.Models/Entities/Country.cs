namespace CornerFlag.Data.Models.Entities
{
    using System.Collections.Generic;

    public class Country : NamedDatabaseEntry
    {
        public Country()
        {
            this.Clubs = new HashSet<Club>();
            this.Competitions = new HashSet<Competition>();
        }

        public virtual ICollection<Club> Clubs { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
