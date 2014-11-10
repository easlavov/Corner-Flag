namespace CornerFlag.Web.Controllers
{
    using System.Web.Mvc;

    using CornerFlag.Common;
    using XMLSoccerCOM;
    using CornerFlag.SoccerData;

    public class BaseController : Controller
    {
        protected CachedSoccerData soccerData;

        public BaseController()
        {
            this.soccerData = new CachedSoccerData();
        }
    }
}