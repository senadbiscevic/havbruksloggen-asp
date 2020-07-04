namespace Havbruksloggen.Business.Responses
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public string Message { get; set; }

        public bool HasError { get; set; }

        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
