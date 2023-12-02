using Newtonsoft.Json;

namespace XRPL.FoundationDataApi.Domain.Responses
{
    public class BaseServerResponse<T> : IResponse
    {
        public HttpResponseMessage Response { get; set; }
        public ApiErrorInfo ErrorInfo { get; set; }
        public T Data { get; set; }
    }

    public interface IResponse
    {
        public HttpResponseMessage Response { get; set; }
    }
}
