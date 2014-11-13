using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models.Entities;

namespace CornerFlag.Data.Models.People
{
    public class Team : DatabaseEntity
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public virtual Club Club { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
