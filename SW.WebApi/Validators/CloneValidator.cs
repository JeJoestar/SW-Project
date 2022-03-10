// <copyright file="CloneValidator.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using FluentValidation;
using SW.DAL;

namespace SW.WebAPI.Validators
{
    public class CloneValidator : AbstractValidator<CloneDto>
    {
        public CloneValidator()
        {
            RuleFor(clone => clone.Number).NotEmpty().Matches(@"[0-9]{4}");
            RuleFor(clone => clone.LegionId).NotEmpty().NotEqual(0);
            RuleFor(clone => clone.BaseId).NotNull().NotEqual(0).When(clone => clone.StarshipId == null);
            RuleFor(clone => clone.StarshipId).NotNull().NotEqual(0).When(clone => clone.BaseId == null);
            RuleFor(clone => clone.Qualification).NotEmpty().Matches(@"[a-zA-Z]{4,}").WithMessage("Example: None, Sniper");
            RuleFor(clone => clone.Equipment).NotEmpty().Matches(@"[a-zA-Z]{4,}").WithMessage("Enter any SW weapon or tool like: DX-15A, Saber");
        }
    }
}
