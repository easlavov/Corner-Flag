using CornerFlag.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XMLSoccerCOM;

namespace CornerFlag.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.SoccerData = new Requester(Constants.XmlSoccerApiKey);
        }

        protected Requester SoccerData { get; set; }
    }
}