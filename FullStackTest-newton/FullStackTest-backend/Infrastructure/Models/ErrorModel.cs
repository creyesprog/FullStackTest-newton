using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Models
{
    public class ErrorModel : IErrorModel
    {
        public List<IError> Errors { get; set; }

        public ErrorModel()
        {
            Errors = new List<IError>();
        }
    }

    public class Error : IError
    {
        public string ErrorMessage { get; set; }
    }
}