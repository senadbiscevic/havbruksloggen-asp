using System.Collections.Generic;

namespace Havbruksloggen.Business.Responses
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Message { get; set; }

        public bool HasError { get; set; }

        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
