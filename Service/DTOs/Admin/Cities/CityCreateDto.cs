using System;
using FluentValidation;
using Service.DTOs.Admin.Countries;

namespace Service.DTOs.Admin.Cities
{
	public class CityCreateDto
	{
		public string Name { get; set; }

        public int Population { get; set; }

        public int CountryId { get; set; }

	}

    public class CityCreateDtoValidator : AbstractValidator<CityCreateDto>
    {
        public CityCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.CountryId).NotNull().WithMessage("Country Id is required");
            RuleFor(x => x.Population).NotNull().WithMessage("Population is required");


        }
    }
}

