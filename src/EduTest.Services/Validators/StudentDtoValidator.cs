using EduTest.Services.DTOs;
using FluentValidation;
using System;

namespace EduTest.Services.Validators
{
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().When(e => e.FirstName == null).WithMessage("El campo nombre no puede estar vacio.")
                .MaximumLength(20).WithMessage("El campo nombre ha superado la cantidad máxima(20) de caracteres.");
            RuleFor(c => c.LastName)
                .MaximumLength(50).WithMessage("El campo apellidos ha superado la cantidad máxima(50) de caracteres.")
                .NotEmpty().When(e => e.LastName == null).WithMessage("El campo nombre no puede estar vacio.");
            RuleFor(c => c.DateOfBirth)
                .Must(c => Convert.ToDateTime(c) >= DateTime.UtcNow).WithMessage("No puede superar la fecha actual");
            RuleFor(c => c.Email)
                .NotEmpty().When(e => e.Email == null).WithMessage("El campo correo no puede estar vacio.")
                .EmailAddress().WithMessage("Correo inválido.");
        }
    }
}
