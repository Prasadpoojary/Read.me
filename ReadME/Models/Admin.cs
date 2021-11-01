using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{

    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public long earning { get; set; }
        public bool isSuperuser { get; set; }


        public bool access_user { get; set; }
        public bool access_book { get; set; }
        public bool access_course { get; set; }
        public bool access_payment { get; set; }
        public bool access_comment { get; set; }
        public bool access_ticket { get; set; }
        public bool access_report { get; set; }
        public bool access_subscriber { get; set; }
    }
}
