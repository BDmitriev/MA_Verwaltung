using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models
{
    public class Employee_Roll
    {

        public int Employee_Role_Id { get; set; }


        public int Employee_Id { get; set; }
        public int Roll_Id { get; set; }


        public Employee Employee { get; set; }
        public Roll Roll { get; set; }

    }
}
