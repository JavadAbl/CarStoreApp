using System.Text.Json.Serialization;

namespace CarStoreApp.Server.Helpers.Errors;

public class ErrorResponse
{
    public string Message { get; set; }
    public int StatusCode { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string StackTrace { get; set; }
}

