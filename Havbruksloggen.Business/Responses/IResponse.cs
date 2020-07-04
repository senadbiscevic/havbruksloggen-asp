using System;
using System.Collections.Generic;
using System.Text;

namespace Havbruksloggen.Business.Responses
{
    public interface IResponse
    {
        string Message { get; set; }

        bool HasError { get; set; }

        int StatusCode { get; set; }

        string ErrorMessage { get; set; }
    }
}
