namespace CornerFlag.Data.Models.Entities
{
    using System.Collections.Generic;

    public class Round : DatabaseEntity
    {
        public Round()
        {
            this.Games = new HashSet<Match>();
        }

        public int Number { get; set; }

        public virtual ICollection<Match> Games { get; set; }

        public virtual Season Season { get; set; } 
    }
}
