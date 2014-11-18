namespace CornerFlag.Data.Models
{
    using CornerFlag.Data.Models.People;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [StringLength(1000, MinimumLength=10)]
        public string Content { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
