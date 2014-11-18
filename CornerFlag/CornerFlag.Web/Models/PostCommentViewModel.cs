namespace CornerFlag.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using CornerFlag.Data.Models;
    using CornerFlag.Web.Infrastructure.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int playerId)
        {
            this.PlayerId = playerId;
        }

        public int PlayerId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Content { get; set; }
    }
}