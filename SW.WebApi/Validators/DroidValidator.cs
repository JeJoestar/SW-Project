// <copyright file="DroidValidator.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>
using FluentValidation;
using SW.DAL;

namespace SW.WebAPI.Validators
{
    public class DroidValidator : AbstractValidator<DroidDto>
    {
        public DroidValidator()
        {
            RuleFor(droid => droid.Model).NotEmpty().Matches(@"(^([A-Z]+{1,2})(-{0,1})[A-Z0-9]+$").MaximumLength(6).WithMessage("C-3PO, R2D2 etc.");
            RuleFor(droid => droid.BaseId).NotNull().NotEqual(0).When(droid => droid.StarshipId == null);
            RuleFor(droid => droid.StarshipId).NotNull().NotEqual(0).When(droid => droid.BaseId == null);
            RuleFor(droid => droid.Equipment).NotEmpty().Matches(@"(^[a-zA-Z]|-){4,}").WithMessage("Enter any SW weapon or tool like: DX-15A, Saber");
        }
    }
}
