using BasicWebAPI.DataAccess.Context;
using BasicWebAPI.DataAccess.DTOs;
using BasicWebAPI.DataAccess.Models;
using BasicWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly MyDbContext _context;

        public CompanyService(MyDbContext context)
        {
            _context = context;
        }

        public int Create(CompanyDto companyDto)
        {
            var company = new Company { Name = companyDto.Name };
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company.CompanyId;
        }

        public CompanyDto Update(CompanyDto companyDto)
        {
            var company = _context.Companies.Find(companyDto.CompanyId);

            if (company != null)
            {
                company.Name = companyDto.Name;
                _context.SaveChanges();
            }

            return companyDto;
        }

        public void Delete(int id)
        {
            var company = _context.Companies.Find(id);

            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
        }

        public List<CompanyDto> Get()
        {
            return _context.Companies
                .Select(c => new CompanyDto { CompanyId = c.CompanyId, Name = c.Name })
                .ToList();
        }
    }
}
