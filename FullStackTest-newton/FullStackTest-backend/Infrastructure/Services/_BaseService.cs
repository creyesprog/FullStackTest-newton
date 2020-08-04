using FullStackTest_newton.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Services
{
    public class _BaseService
    {
        protected IErrorModel ErrorModel { get; set; }

        public _BaseService(IErrorModel errorModel)
        {
            ErrorModel = errorModel;
        }

        protected void AddModelError(string error)
        {
            ErrorModel.Errors.Add(new Error { ErrorMessage = error });
        }
    }
}