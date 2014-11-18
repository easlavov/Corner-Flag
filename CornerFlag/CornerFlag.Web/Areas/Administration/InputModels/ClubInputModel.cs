namespace CornerFlag.Web.Areas.Administration.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CornerFlag.Common;
    using CornerFlag.Data.Models.Entities;
    using CornerFlag.Web.Infrastructure.Mapping;

    public class ClubInputModel : IMapFrom<Club>
    {
        [Required]
        [StringLength(20, MinimumLength=2)]
        public string Name { get; set; }

        [Required]
        [DateAttribute(-100, 0)]
        public DateTime DateFounded { get; set; }

        public int CountryId { get; set; }
    }
}