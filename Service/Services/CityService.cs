using System;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class CityService:ICityService
	{
        private readonly ICityRepository _cityRepo;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CityService> _logger;

        public CityService(ICityRepository cityRepo,
                          IMapper mapper,
                          ICountryRepository countryRepository,
                          ILogger<CityService> logger)
		{
            _cityRepo = cityRepo;
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
		}

        public async Task CreateAsync(CityCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();

            var existCountry = await _countryRepository.GetById(model.CountryId);

            if (existCountry is null)
            {

                throw new NotFoundException($" Id-{model.CountryId} Data Not Found");
            }

            await _cityRepo.CreateAsync(_mapper.Map<City>(model));
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.GetAllWithCountry());

        }

        public async Task<CityDto> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var data = _cityRepo.FindBy(m => m.Id == id, m => m.Country);

            //var existCity = await _cityRepo.GetById((int)id);

            //if (existCity is null) throw new NullReferenceException();

            return _mapper.Map<CityDto>(data.FirstOrDefault());
        }

        public async Task<CityDto> GetByName(string name)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            var data = _cityRepo.FindBy(m => m.Name == name, m => m.Country);

            return _mapper.Map<CityDto>(data.FirstOrDefault());

        }
    }
}

