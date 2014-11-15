using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CornerFlag.Data.Models.Entities;
using CornerFlag.Data.Models.People;

namespace CornerFlag.Web.Models
{
    public class HomeViewModel
    {
        public IQueryable<Competition> Competitions { get; set; }

        public IQueryable<Club> Clubs { get; set; }

        public IQueryable<Team> Teams { get; set; }
    }
}