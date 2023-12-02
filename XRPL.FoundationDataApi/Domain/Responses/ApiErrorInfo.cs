namespace XRPL.FoundationDataApi.Domain.Responses;

public class ApiErrorInfo
{
    public string message { get; set; }
    public string code { get; set; }
    public string path { get; set; }
}