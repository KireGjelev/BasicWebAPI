using BasicWebAPI.DataAccess.Context;
using BasicWebAPI.DataAccess.DTOs;
using BasicWebAPI.DataAccess.Models;
using BasicWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly MyDbContext _context;

        public CountryService(MyDbContext context)
        {
            _context = context;
        }

        public int Create(CountryDto countryDto)
        {
            var country = new Country { CountryName = countryDto.CountryName };
            _context.Countries.Add(country);
            _context.SaveChanges();
            return country.CountryId;
        }

        public CountryDto Update(CountryDto countryDto)
        {
            var country = _context.Countries.Find(countryDto.CountryId);

            if (country != null)
            {
                country.CountryName = countryDto.CountryName;
                _context.SaveChanges();
            }

            return countryDto;
        }

        public void Delete(int id)
        {
            var country = _context.Countries.Find(id);

            if (country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
        }

        public List<CountryDto> Get()
        {
            return _context.Countries
                .Select(c => new CountryDto { CountryId = c.CountryId, CountryName = c.CountryName })
                .ToList();
        }
    }
}
