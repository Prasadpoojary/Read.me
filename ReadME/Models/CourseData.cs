using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadME.Models
{
    public class CourseData
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }

        public IFormFile ThumbnailFile { get; set; }
        public string URL { get; set; }
    }
}
