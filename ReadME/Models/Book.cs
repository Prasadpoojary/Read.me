using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class Book
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public long Price { get; set; }

        public int Uploader { get; set; }
        public bool IsPremium { get; set; }



        public string ThumbnailPath { get; set; }
        public string FilePath { get; set; }

        public DateTime UploadTime { get; set; }


        public long Likes { get; set; }
        public long Readers { get; set; }
        public long Comments { get; set; }
    }
}
