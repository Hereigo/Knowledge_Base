using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Xml.Linq;
using AngularJS_ASPnet48_XML.Models;

namespace AngularJS_ASPnet48_XML.DataAccess
{
    public class DetailsData
    {
        private readonly string dataSource = HostingEnvironment.MapPath("~/Data/Detail.xml");
        private readonly XDocument xdoc;

        public DetailsData()
        {
            try
            {
                if (!File.Exists(dataSource))
                {
                    throw new Exception($"Can not find DataSource: {dataSource}");
                }
                else
                {
                    xdoc = XDocument.Load(dataSource);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"DataSource : {dataSource} is not accessible!", e);
            }
        }

        internal Detail GetByIdWithoutPrice(string id)
        {
            foreach (XElement xdocElement in xdoc.Element("Store").Element("Products").Elements("Product"))
            {
                string attributeId = xdocElement.Attribute("id")?.Value;

                if (attributeId.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    List<string> specs = new List<string>();

                    foreach (var item in xdocElement.Element("Specs")?.Elements("Spec"))
                    {
                        specs.Add(item.Value);
                    }

                    return new Detail
                    {
                        // TODO:
                        // should be imlemented via Enum.
                        // Availability = (Availability)Enum.Parse(typeof(Availability), phoneElement.Element("Availability")?.Value),
                        Availability = xdocElement.Element("Availability")?.Value,
                        Description = xdocElement.Element("Description")?.Value,
                        Id = xdocElement.Attribute("id")?.Value,
                        Image = xdocElement.Element("Image")?.Value,
                        Title = xdocElement.Element("Title")?.Value,
                        Specs = specs
                    };
                }
            }

            return new Detail();
        }

        internal IEnumerable<KeyValuePair<string, string>> GetAvailabilities()
        {
            foreach (XElement xdocElement in xdoc.Element("Store").Element("Products").Elements("Product"))
            {
                yield return new KeyValuePair<string, string>(
                    xdocElement.Attribute("id")?.Value,
                    xdocElement.Element("Availability")?.Value);
            }
        }

        internal IEnumerable<Detail> GetAll()
        {
            foreach (XElement xdocElement in xdoc.Element("Store").Element("Products").Elements("Product"))
            {
                List<string> specs = new List<string>();

                foreach (var item in xdocElement.Element("Specs")?.Elements("Spec"))
                {
                    specs.Add(item.Value);
                }

                yield return new Detail
                {
                    Availability = xdocElement.Element("Availability")?.Value,
                    Description = xdocElement.Element("Description")?.Value,
                    Id = xdocElement.Attribute("id").Value,
                    Image = xdocElement.Element("Image").Value,
                    Title = xdocElement.Element("Title").Value,
                    Specs = specs
                };
            }
        }
    }
}