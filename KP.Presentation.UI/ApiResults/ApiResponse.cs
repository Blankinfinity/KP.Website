using Newtonsoft.Json;

namespace KP.Presentation.UI.ApiResults
{
  /// <summary>
  /// Class ApiResponse designed to give a consistent client experience by returning
  /// the same response structure in all cases even when the request was unsuccessful.
  /// https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api
  /// </summary>
  public class ApiResponse
  {
    public int StatusCode { get; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; }

    public ApiResponse(int statusCode, string message = null)
    {
      StatusCode = statusCode;
      Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    private static string GetDefaultMessageForStatusCode(int statusCode)
    {
      switch (statusCode)
      {
        case 400:
          return "Object is null";
        case 404:
          return "Resource not found";
        case 500:
          return "An unhandled error occurred";
        default:
          return null;
      }
    }
  }
}
