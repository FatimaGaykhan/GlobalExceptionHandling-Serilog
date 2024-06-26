using System;
using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;

namespace Service.Helpers
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
            CreateMap<CountryCreateDto, Country>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryEditDto, Country>();

            CreateMap<CityCreateDto, City>();
            CreateMap<City, CityDto>().ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));


        }
    }
}

