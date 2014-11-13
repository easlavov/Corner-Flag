namespace CornerFlag.Data.Models.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CornerFlag.Data.Models.Entities;

    public class Player : Person
    {
        public Club Club { get; set; }

        public Position Position { get; set; }
    }
}
