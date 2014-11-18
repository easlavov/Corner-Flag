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
    public class PlayersController : BaseController
    {
        public PlayersController(ICornerFlagData data)
            : base(data)
        {

        }

        public ActionResult Details(int id)
        {
            Mapper.CreateMap<Comment, CommentViewModel>();
            var player = this.data.Players.GetById(id);
            return View(player);
        }        
    }
}