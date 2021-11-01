using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class Permission
    {
        public bool user { get; set; }
        public bool book { get; set; }
        public bool course { get; set; }
        public bool report { get; set; }
        public bool ticket { get; set; }
        public bool subscriber { get; set; }
        public bool comment { get; set; }
        public bool payment { get; set; }
    }
}
