using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public Employee Employee { get; set; }

        public string Strasse { get; set; }

        public string Plz { get; set; }

        public string Stadt{ get; set; }

        public string Land { get; set; }
    }
}
