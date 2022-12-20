using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entityOrDto)
        {
            var context = new ValidationContext<object>(entityOrDto);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
