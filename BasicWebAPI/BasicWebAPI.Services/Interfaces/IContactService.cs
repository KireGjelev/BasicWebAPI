using BasicWebAPI.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Interfaces
{
    public interface IContactService
    {
        int Create(ContactDto contactDto);
        ContactDto Update(ContactDto contactDto);
        void Delete(int id);
        List<ContactDto> Get();
        List<ContactInfoDto> GetContactsWithCompanyAndCountry();
        List<ContactDto> FilterContacts(int? countryId, int? companyId);
    }

}
