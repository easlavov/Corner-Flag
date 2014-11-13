using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornerFlag.Data.Models
{
    public class NamedDatabaseEntry : DatabaseEntity
    {
        private const int MINIMUM_NAME_LENGTH = 2;
        private const int MAXIMUM_NAME_LENGTH = 20;
        private const string MIN_LENGTH_ERROR_MESSAGE = "Miniumum length is 2!";
        private const string MAX_LENGTH_ERROR_MESSAGE = "Maximum length is 20!";

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(MINIMUM_NAME_LENGTH, ErrorMessage = MIN_LENGTH_ERROR_MESSAGE)]
        [MaxLength(MAXIMUM_NAME_LENGTH, ErrorMessage = MAX_LENGTH_ERROR_MESSAGE)]
        public string Name { get; set; }
    }
}
