using System;
using FluentValidation;
using OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;

namespace OmegaGymServer.Application.Validator.UserValidator
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(3).MaximumLength(50).WithMessage("The entered character must be at least {PropertyName} 4 and at most {propertyname} 50 characters long.");

            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(3).MaximumLength(50).WithMessage("The entered character must be at least {PropertyName} 4 and at most {propertyname} 50 characters long.");

            RuleFor(u => u.UserName).NotNull();
            RuleFor(u => u.UserName).MinimumLength(3).MaximumLength(50).WithMessage("The entered character must be at least {PropertyName} 4 and at most {propertyname} 50 characters long.");

            RuleFor(u => u.Email).NotNull().EmailAddress().WithMessage("{PropertyName} is a valid email address");

            RuleFor(u => u.Password).NotNull().MinimumLength(6).WithMessage("{PropertyName} should at last be {MinLenght} character");
        }
    }
}

