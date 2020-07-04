using System;
using Microsoft.Extensions.Logging;
using Havbruksloggen.Common;
using Havbruksloggen.Common.Enum;

namespace Havbruksloggen.Business.Responses
{
    public static class ResponseExtensions
    {
        
        public static void SetError(this IResponse response, Exception ex)
        {
            response.HasError = true;

            response.ErrorMessage = "There was an internal error, please contact technical support.";
        }
    }
}
