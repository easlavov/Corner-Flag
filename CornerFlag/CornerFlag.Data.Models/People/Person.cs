namespace CornerFlag.Data.Models.People
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CornerFlag.Common;
    using CornerFlag.Data.Models.Entities;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Person : DatabaseEntity
    {
        private const int MINIMUM_NAME_LENGTH = 2;
        private const int MAXIMUM_NAME_LENGTH = 20;
        private const string MIN_LENGTH_ERROR_MESSAGE = "Miniumum length is 2!";
        private const string MAX_LENGTH_ERROR_MESSAGE = "Maximum length is 20!";

        [Required(ErrorMessage = "First Name is required!")]
        [MinLength(MINIMUM_NAME_LENGTH, ErrorMessage = MIN_LENGTH_ERROR_MESSAGE)]
        [MaxLength(MAXIMUM_NAME_LENGTH, ErrorMessage = MAX_LENGTH_ERROR_MESSAGE)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [MinLength(MINIMUM_NAME_LENGTH, ErrorMessage = MIN_LENGTH_ERROR_MESSAGE)]
        [MaxLength(MAXIMUM_NAME_LENGTH, ErrorMessage = MAX_LENGTH_ERROR_MESSAGE)]
        public string LastName { get; set; }

        [Required]
        [DateAttribute(-100, -6)]
        public DateTime BirthDate { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - this.BirthDate.Year);
            }
        }
    }
}
