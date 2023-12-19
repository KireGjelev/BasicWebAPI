using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
