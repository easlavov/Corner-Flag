namespace CornerFlag.Data.Models.People
{
    using System.Collections.Generic;

    using CornerFlag.Data.Models.Entities;

    public class Player : Person
    {
        public Player()
        {
            this.Teams = new HashSet<Team>();
        }

        public Club Club { get; set; }

        public Position Position { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
