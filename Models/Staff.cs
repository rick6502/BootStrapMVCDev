using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootStrapMVCDev.Models
{
    public class Staff
    {
        public string UserID { get; set; }
        public string PersonnelName { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StatActive { get; set;  }
        public int IsActive { get; set; }
        public int TeamCode { get; set; }
        public int SubteamCode { get; set; }

    }
}
