using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SourceId { get; set; }
        public string Source { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
