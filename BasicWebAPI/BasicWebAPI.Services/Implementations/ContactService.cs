using BasicWebAPI.DataAccess.Context;
using BasicWebAPI.DataAccess.DTOs;
using BasicWebAPI.DataAccess.Models;
using BasicWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly MyDbContext _context;

        public ContactService(MyDbContext context)
        {
            _context = context;
        }

        public int Create(ContactDto contactDto)
        {
            var contact = new Contact
            {
                ContactName = contactDto.ContactName,
                CompanyId = contactDto.CompanyId,
                CountryId = contactDto.CountryId
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact.ContactId;
        }

        public ContactDto Update(ContactDto contactDto)
        {
            var contact = _context.Contacts.Find(contactDto.ContactId);

            if (contact != null)
            {
                contact.ContactName = contactDto.ContactName;
                contact.CompanyId = contactDto.CompanyId;
                contact.CountryId = contactDto.CountryId;
                _context.SaveChanges();
            }

            return contactDto;
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public List<ContactDto> Get()
        {
            return _context.Contacts
                .Select(c => new ContactDto
                {
                    ContactId = c.ContactId,
                    ContactName = c.ContactName,
                    CompanyId = c.CompanyId,
                    CountryId = c.CountryId
                })
                .ToList();
        }

        public List<ContactInfoDto> GetContactsWithCompanyAndCountry()
        {
            return _context.Contacts
                .Include(c => c.Company)
                    .ThenInclude(company => company.Country)
                .Select(contact => new ContactInfoDto
                {
                    ContactId = contact.ContactId,
                    ContactName = contact.ContactName,
                    CompanyName = contact.Company.Name,
                    CountryName = contact.Company.Country.CountryName
                })
                .ToList();
        }

        public List<ContactDto> FilterContacts(int? countryId, int? companyId)
        {
            var query = _context.Contacts.AsQueryable();

            if (countryId.HasValue)
            {
                query = query.Where(c => c.CountryId == countryId.Value);
            }

            if (companyId.HasValue)
            {
                query = query.Where(c => c.CompanyId == companyId.Value);
            }

            return query
                .Select(c => new ContactDto
                {
                    ContactId = c.ContactId,
                    ContactName = c.ContactName,
                    CompanyId = c.CompanyId,
                    CountryId = c.CountryId
                })
                .ToList();
        }
    }
}
