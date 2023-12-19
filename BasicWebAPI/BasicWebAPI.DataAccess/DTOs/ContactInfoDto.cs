using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.DTOs
{
    public class ContactInfoDto
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
    }
}
