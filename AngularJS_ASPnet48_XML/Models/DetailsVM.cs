using System.Collections.Generic;

namespace AngularJS_ASPnet48_XML.Models
{
    public class DetailsVM
    {
        public decimal Price { get; set; }

        public IEnumerable<string> Specs { get; set; }

        public string Description { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
    }
}