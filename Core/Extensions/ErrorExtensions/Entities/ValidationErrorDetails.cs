using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Extensions.ErrorExtensions.Entities
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}
