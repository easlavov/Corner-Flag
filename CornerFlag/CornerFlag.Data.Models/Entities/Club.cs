using CornerFlag.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornerFlag.Data.Models;
using CornerFlag.Data.Models.People;
using System.ComponentModel.DataAnnotations.Schema;

namespace CornerFlag.Data.Models.Entities
{
    public class Club : NamedDatabaseEntry
    {
        public Club()
        {
            this.Competitions = new HashSet<Competition>();
        }

        [Required]
        [DateAttribute(-100, 0)]
        public DateTime DateFounded { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }

        public virtual ICollection<Player> Team { get; set; }        
    }
}
