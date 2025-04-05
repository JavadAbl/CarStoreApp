namespace CarStoreApp.Server.Helpers.Errors;

public class NotFoundHttpException : Exception
{
    public int StatusCode { get; } = 404;

    public NotFoundHttpException(string message) : base(message) { }
}


