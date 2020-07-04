using System.Collections.Generic;

namespace Havbruksloggen.Business.Responses
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
