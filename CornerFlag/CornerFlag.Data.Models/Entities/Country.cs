using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models;

namespace CornerFlag.Data.Models.Entities
{
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
