using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consultancy.Project.Areas.Admin.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageLength { get; set; }
        public string ImageTitle { get; set; }
        public string ImageSize { get; set; }
    }
}