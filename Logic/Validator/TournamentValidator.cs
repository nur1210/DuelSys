using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Logic.Models;

namespace Logic.Validator
{
    public class TournamentValidator : AbstractValidator<Tournament>
    {
        public TournamentValidator()
        {
            RuleFor(t => t.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 50).WithMessage("{PropertyName} must be between 2 and 50 characters")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("{PropertyName} must be alphanumeric");

            RuleFor(t => t.Location)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(3, 50).WithMessage("{PropertyName} must be between 3 and 50 characters")
                .Matches("^[a-zA-Z ]*$").WithMessage("{PropertyName} can contain only characters");

            RuleFor(t => t.EndDate)
                .GreaterThan(t => t.StartDate).WithMessage("{PropertyName} must be bigger then start date");
        }
    }
}
