using System;

namespace TestTemplateAI1.Application.Sorting;

public class InvalidPropertyMappingException : Exception
{
    public InvalidPropertyMappingException(string message)
        : base(message)
    {
    }
}
