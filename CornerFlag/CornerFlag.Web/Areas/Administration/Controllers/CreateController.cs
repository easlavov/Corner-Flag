using AutoMapper;
using CornerFlag.Data;
using CornerFlag.Data.Models.Entities;
using CornerFlag.Web.Areas.Administration.InputModels;
using CornerFlag.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Areas.Administration.Controllers
{
    //[Authorize(Roles="Admin")]
    public class CreateController : BaseController
    {
        public CreateController(ICornerFlagData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Country()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Country(Country model)
        {
            if (this.ModelState.IsValid)
            {
                var country = model;
                this.data.Countries.Add(country);
                this.data.SaveChanges();
            }

            return RedirectToAction("Country");
        }

        [HttpGet]
        public ActionResult Club()
        {
            var countries = this.data.Countries.All();
            var list = new SelectList(countries, "Id", "Name");
            this.ViewBag.Countries = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Club(ClubInputModel input)
        {
            if (this.ModelState.IsValid)
            {
                Mapper.CreateMap<ClubInputModel, Club>();
                var club = Mapper.Map<Club>(input);
                this.data.Clubs.Add(club);
                this.data.SaveChanges();
            }

            return RedirectToAction("Club");
        }
    }
}