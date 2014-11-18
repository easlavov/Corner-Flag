using CornerFlag.Data;
using CornerFlag.Data.Models.Entities;
using CornerFlag.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CornerFlag.Web.Areas.Administration.Controllers
{
    [Authorize(Roles="Admin")]
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
            this.ViewBag.Countries = countries.Select(
                                                x => new SelectListItem() 
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                });
            //var countriesSelectList = new SelectList(countries, "Id", "Name") as IEnumerable<SelectListItem>;
            //this.ViewBag.Countries = countriesSelectList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Club(Club model)
        {
            if (this.ModelState.IsValid)
            {
                var club = model;
                this.data.Clubs.Add(club);
                this.data.SaveChanges();
            }

            return RedirectToAction("Club");
        }
    }
}