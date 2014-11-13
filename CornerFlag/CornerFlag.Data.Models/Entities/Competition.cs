using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models;

namespace CornerFlag.Data.Models.Entities
{
    public class Competition : NamedDatabaseEntry
    {
        public Competition()
        {
            this.Seasons = new HashSet<Season>();
        }

        public Country Country { get; set; }

        public virtual ICollection<Season> Seasons { get; set; }
    }
}
