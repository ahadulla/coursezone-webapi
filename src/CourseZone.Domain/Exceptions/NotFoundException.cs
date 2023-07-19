using System.Net;

namespace CourseZone.Domain.Exceptions;

public class NotFoundException : Exception
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}
