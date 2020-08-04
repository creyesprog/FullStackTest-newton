using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackTest_newton.Infrastructure.Models.DTOs
{
    public class ResponseDTO : ErrorModel
    {
        public ResponseDTO(IErrorModel errorModel)
        {
            Errors = errorModel.Errors;
        }
    }
}