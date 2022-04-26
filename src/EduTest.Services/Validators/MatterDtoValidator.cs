using EduTest.Services.DTOs;
using FluentValidation;

namespace EduTest.Services.Validators
{
    public class MatterDtoValidator : AbstractValidator<MatterDto>
    {
        public MatterDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("El campo nombre no puede estar vacio.")
                .MaximumLength(20).WithMessage("El campo nombre ha superado la cantidad máxima(20) de caracteres.");

            RuleFor(c => c.CourseId)
                .NotNull().WithMessage("Debe seleccionar un curso.");
        }
    }
}
