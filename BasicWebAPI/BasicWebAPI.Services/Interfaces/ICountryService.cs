using BasicWebAPI.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        int Create(CountryDto countryDto);
        CountryDto Update(CountryDto countryDto);
        void Delete(int id);
        List<CountryDto> Get();
    }
}
