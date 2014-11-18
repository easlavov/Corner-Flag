namespace CornerFlag.Web.Areas.Administration.InputModels
{
    using CornerFlag.Common;
    using CornerFlag.Data.Models.People;
    using CornerFlag.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PlayerInputModel : IMapFrom<Player>
    {
        [Required]
        [StringLength(20, MinimumLength=2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DateAttribute(-100, -6)]
        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public Position Position { get; set; }
    }
}