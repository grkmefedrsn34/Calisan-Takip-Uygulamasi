using FluentValidation.Results;
using TaskManagentment.Application.DTOs;

namespace TaskManagentment.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static List<ValidationErorrs> ToMap(this List<ValidationFailure> errors)
        {
            var errorList = new List<ValidationErorrs>();

            foreach (var error in errors)
            {
                errorList.Add(new ValidationErorrs(error.PropertyName, error.ErrorMessage));
            }

            return errorList;
        }
    }
}
