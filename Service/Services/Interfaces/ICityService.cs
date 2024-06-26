using System;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;

namespace Service.Services.Interfaces
{
	public interface ICityService
	{
        Task<IEnumerable<CityDto>> GetAllAsync();

        Task CreateAsync(CityCreateDto model);

        Task<CityDto> GetByIdAsync(int? id);

        Task<CityDto> GetByName(string name);

        //Task DeleteAsync(int? id);

        //Task EditAsync(CountryEditDto model, int? id);
    }
}

