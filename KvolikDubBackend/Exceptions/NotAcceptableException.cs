﻿namespace KvolikDubBackend.Exceptions;

public class NotAcceptableException : Exception
{
    public NotAcceptableException(string message) : base(message)
    {
    }
}