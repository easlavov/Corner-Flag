namespace CornerFlag.Web.Controllers
{
    using System.Web.Mvc;

    using CornerFlag.Data;

    public class BaseController : Controller
    {
        protected ICornerFlagData data;

        public BaseController(ICornerFlagData data)
        {
            this.data = data;
        }
    }
}