namespace CornerFlag.Web.Controllers
{
    using System.Web.Mvc;

    using CornerFlag.Common;
    using XMLSoccerCOM;

    public class BaseController : Controller
    {
        protected Requester soccerData;

        public BaseController()
        {
            this.soccerData = new Requester(Constants.XmlSoccerApiKey, true);
        }
    }
}