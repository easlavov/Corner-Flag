using AutoMapper;
using CornerFlag.Data;
using CornerFlag.Data.Models;
using CornerFlag.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ICornerFlagData data)
            : base(data)
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel input)
        {
            Mapper.CreateMap<Comment, CommentViewModel>();
            
                var comment = new Comment
                {
                    Content = input.Content,
                    PlayerId = input.PlayerId
                };
                var player = this.data.Players.GetById(input.PlayerId);
                if (player == null)
                {
                    throw new HttpException(404, "Player not found");
                }

                player.Comments.Add(comment);
                this.data.SaveChanges();

                var view = Mapper.Map<CommentViewModel>(comment);
                return PartialView("_CommentView", view);

            //throw new HttpException(400, "Invalid comment");
        }
    }
}