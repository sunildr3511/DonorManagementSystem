using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class DonorCreateCommandValidator : AbstractValidator<DonorCreateCommand>
    {
        public DonorCreateCommandValidator()
        {
            RuleForEach(p => p.StakeHolders).SetValidator(new StakeHolderVariantValidator());
        }
    }

    public class StakeHolderVariantValidator : AbstractValidator<StakeHolderVM>
    {
        public StakeHolderVariantValidator()
        {
            RuleFor(p => p.DecisionMakingRole)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();

            RuleFor(p => p.Salutation)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
        }
    }

}
