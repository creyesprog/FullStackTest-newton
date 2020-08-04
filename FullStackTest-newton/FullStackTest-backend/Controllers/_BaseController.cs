using FullStackTest_newton.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;

namespace FullStackTest_newton.Controllers
{
    public class _BaseController : ApiController
    {
        protected IErrorModel ErrorModel;

        public _BaseController() : base()
        {
        }

        protected void AddModelError(string error)
        {
            ErrorModel.Errors.Add(new Error() { ErrorMessage = error });
        }
    }
}