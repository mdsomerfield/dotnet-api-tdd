﻿namespace Mds.TddExample.Domain.Exceptions;

public abstract class ApplicationException : Exception
{
    protected ApplicationException(string message) : base(message)
    {

    }
}