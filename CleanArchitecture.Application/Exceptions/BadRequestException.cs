using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {
        ValidationErrors = new Dictionary<string, string>();
    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage);
    }

    public IDictionary<string, string> ValidationErrors { get; set; }
}
