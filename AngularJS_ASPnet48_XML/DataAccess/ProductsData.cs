using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Xml.Linq;
using AngularJS_ASPnet48_XML.Models;

namespace AngularJS_ASPnet48_XML.DataAccess
{
    public class ProductsData
    {
        private readonly string dataSource = HostingEnvironment.MapPath("~/Data/list.xml");
        private readonly XDocument xdoc;

        public ProductsData()
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

        internal IEnumerable<Product> GetAll()
        {
            foreach (XElement xdocElement in xdoc.Element("Store").Element("Products").Elements("Product"))
            {
                yield return new Product
                {
                    Description = xdocElement.Element("Description")?.Value,
                    Id = xdocElement.Attribute("id").Value,
                    Image = xdocElement.Element("Image").Value,
                    Popular = int.Parse(xdocElement.Element("Sorting")?.Element("Popular")?.Value),
                    Price = decimal.Parse(xdocElement.Element("Price").Value),
                    Title = xdocElement.Element("Title").Value
                };
            }
        }
    }
}