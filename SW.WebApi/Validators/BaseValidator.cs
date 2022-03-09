// <copyright file="BaseValidator.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>
using FluentValidation;
using SW.DAL;

namespace SW.WebAPI.Validators
{
    public class BaseValidator : AbstractValidator<BaseDto>
    {
        public BaseValidator()
        {
            RuleFor(basee => basee.AmmoSupply).SetValidator(new AmmoSupplyValidator());
        }
        public class AmmoSupplyValidator : AbstractValidator<Supply>
        {
            public AmmoSupplyValidator()
            {
                RuleFor(supply => supply.GrenadesCount).NotEmpty().InclusiveBetween(0, 5000);
                RuleFor(supply => supply.CartridgesCount).NotEmpty().InclusiveBetween(0, 25000);
                RuleFor(supply => supply.FuelLitresAmount).NotEmpty().InclusiveBetween(0, 400000);
            }
        }
    }
}
