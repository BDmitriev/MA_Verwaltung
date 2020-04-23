using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models
{
    public class Roll
    {
        public int RollId { get; set; }

        public ICollection<Employee_Roll> Employee_Rolls { get; set; }


        public string Occupation { get; set; }

        public string Rolle { get; set; }

        public string Fachgebiet { get; set; } = null;
    }
}
