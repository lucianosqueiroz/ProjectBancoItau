using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectBancoItau.MVC.Infra
{
    public class BaseController: Controller
    {
        protected ActionResult Content(HttpStatusCode status, string value = "")
        {
            Response.StatusCode = (int)status;
            Response.TrySkipIisCustomErrors = true;
            return Content(value);
        }


        protected ActionResult Error(string message) => Content(HttpStatusCode.BadRequest, message);

        protected ActionResult Error(IEnumerable<string> messages) => Content(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(messages));

        protected ActionResult NotAcceptable(string message) => Content(HttpStatusCode.NotAcceptable, message);

        protected ActionResult Success() => Content(HttpStatusCode.OK);

        protected ActionResult Success(string message) => Content(HttpStatusCode.OK, message);

        protected ActionResult Success<T>(T content) => content == null ? Success() : Json(content, JsonRequestBehavior.AllowGet);
    }
}
