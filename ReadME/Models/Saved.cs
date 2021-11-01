using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class Saved
    {
        public int Id { get; set; }


        public int UserId { get; set; }

        public bool isBook { get; set; }

        public int SourceId { get; set; }

        public DateTime SavedTime { get; set; }
    }
}
