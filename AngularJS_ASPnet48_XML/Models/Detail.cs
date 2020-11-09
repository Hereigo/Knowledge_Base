using System.Collections.Generic;
using System.Collections;
using System;

namespace AngularJS_ASPnet48_XML.Models
{
    public enum Availability
    {
        // TODO:
        // collect all possible values.
    }

    public class Detail
    {
        // should be imlemented via Enum.
        public string Availability { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Specs { get; set; }
    }
}