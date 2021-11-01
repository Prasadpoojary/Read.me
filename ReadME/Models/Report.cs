using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsBook { get; set; }
        public int ResourceId { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
