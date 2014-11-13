using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CornerFlag.Data.Models.Entities
{
    public class Season : DatabaseEntity
    {
        public Season()
        {
            this.Rounds = new HashSet<Round>();
        }

        [Range(1872, 3000)]
        public int StartYear { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
