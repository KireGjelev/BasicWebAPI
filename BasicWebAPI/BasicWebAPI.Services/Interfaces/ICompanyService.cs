using BasicWebAPI.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Interfaces
{
    public interface ICompanyService
    {
        int Create(CompanyDto companyDto);
        CompanyDto Update(CompanyDto companyDto);
        void Delete(int id);
        List<CompanyDto> Get();
    }
}
