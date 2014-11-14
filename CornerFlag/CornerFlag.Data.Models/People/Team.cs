using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models.Entities;

namespace CornerFlag.Data.Models.People
{
    public class Team : NamedDatabaseEntry
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public virtual Club Club { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
