using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornerFlag.Data.Models.Entities
{
    public class Round : DatabaseEntity
    {
        public Round()
        {
            this.Games = new HashSet<Match>();
        }

        public int Number { get; set; }

        public virtual ICollection<Match> Games { get; set; }

        public virtual Season Season { get; set; }

        public bool IsCompleted { get; set; }        
    }
}
