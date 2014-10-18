using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoMice.Models
{
    using System.Data.Entity.Migrations;
    using System.Reflection;
    using System.Xml.Linq;

    public class CreateSeedData
    {
        public static void CreateSeedDataHelper(AcronymContext context)
        {
            var resourceName = "InfoMice.SeedData.acronyms.xml";;
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resourceName);
            var xml = XDocument.Load(stream);
            var acronyms = xml.Element("acronyms")
                              .Elements("acronym")
                              .Select((a, index) => new Acronym
                              {
                                  AcronymId = index,
                                  Abreviation = (string)a.Element("abrev"),
                                  FullName = (string)a.Element("meaning")
                              }).ToArray();
            context.Acronyms.AddOrUpdate(a => a.AcronymId, acronyms);
        }
    }
}