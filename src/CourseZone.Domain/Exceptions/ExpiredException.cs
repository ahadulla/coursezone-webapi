using System.Net;

namespace CourseZone.Domain.Exceptions;

public class ExpiredException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;

    public string TitleMessage { get; protected set; } = String.Empty;
}
