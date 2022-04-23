using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class StakeHolderCreateCommandValidator :AbstractValidator<StakeHolderCreateCommand>
    {
        public StakeHolderCreateCommandValidator()
        {
            RuleFor(p => p.DecisionMakingRole)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Salutation)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        }
    }
}
