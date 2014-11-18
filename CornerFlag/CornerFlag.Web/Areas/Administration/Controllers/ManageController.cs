namespace CornerFlag.Web.Areas.Administration.Controllers
{
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CornerFlag.Web.Controllers;
    using CornerFlag.Web.Areas.Administration.ViewModels;
    using AutoMapper.QueryableExtensions;
    using CornerFlag.Data;

    public class ManageController : BaseController
    {
        public ManageController(ICornerFlagData data)
            : base(data)
        {
        }

        public ActionResult Countries()
        {
            return View();
        }

        public ActionResult Countries_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CountryViewModel> products = this.data.Countries.AllWithDeleted().Project().To<CountryViewModel>();
            DataSourceResult result = products.ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Edit_Country([DataSourceRequest]DataSourceRequest request, CountryViewModel input)
        {
            try
            {
                var postToUpdate = this.data.Countries.GetById(input.Id);
                postToUpdate.Name = input.Name;

                this.data.Countries.SaveChanges();
            }
            catch (Exception)
            {
            }

            return Json(new[] { input }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Destroy_Country([DataSourceRequest]DataSourceRequest request, CountryViewModel input)
        {
            try
            {
                var postId = this.data.Countries.GetById(input.Id);
                this.data.Countries.Delete(postId);
                this.data.Countries.SaveChanges();
            }
            catch (Exception)
            {
            }

            return Json(new[] { input }.ToDataSourceResult(request, ModelState));
        }
    }
}