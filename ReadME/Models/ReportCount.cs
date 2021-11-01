using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class ReportCount
    {
        public string reportId { get; set; }

        public bool IsBook { get; set; }

        public int ResourceId { get; set; }
        public DateTime firstDate { get; set; }
        public int Count {get;set;}

    }
}
