namespace CornerFlag.Data.Models.People
{
    using System.Collections.Generic;

    using CornerFlag.Data.Models.Entities;

    public class Player : Person
    {
        public Player()
        {
            this.Teams = new HashSet<Team>();
            this.Comments = new HashSet<Comment>();
        }

        public Position Position { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
