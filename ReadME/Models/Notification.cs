using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
