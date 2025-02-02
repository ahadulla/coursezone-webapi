﻿using System.Net;

namespace CourseZone.Domain.Exceptions;

public class AlreadyExistsExcaption : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}
