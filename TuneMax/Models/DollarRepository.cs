using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TuneMax.Models
{
    public class DollarRepository : DollarRepository_
    {
        private List<Dollar> allDollars;
        private XDocument DollarData;

        public DollarRepository()
        {
            allDollars = new List<Dollar>();
            DollarData = XDocument.Load(HttpContext.Current.Server.MapPath("~/Dollar.xml"));
            var Dollars = from t in DollarData.Descendants("item")
                            select new Dollar(
                                (int)t.Element("id"),
                                t.Element("date").Value,
                            t.Element("price").Value);
            allDollars.AddRange(Dollars.ToList<Dollar>());
        }

        public IEnumerable<Dollar> GetDollars()
        {
            return allDollars;
        }

        public string CurrentDollar()
        {
            return allDollars.Last().price.ToString();
        }

        public void InsertDollar(Dollar dollar)
        {
            dollar.ID = (int)(from b in DollarData.Descendants("item") orderby (int)b.Element("id") descending select (int)b.Element("id")).FirstOrDefault() + 1;
            DollarData.Root.Add(new XElement("item", new XElement("id", dollar.ID),
                new XElement("date", DateTime.Now.Year.ToString() + " " + DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " - " + DateTime.Now.ToShortTimeString()),
                new XElement("price", dollar.price)));
            DollarData.Save(HttpContext.Current.Server.MapPath("~/Dollar.xml"));
        }
        public void DeleteAllDollars()
        {
            DollarData.Root.Elements("item").Remove();
            DollarData.Save(HttpContext.Current.Server.MapPath("~/Dollar.xml"));
        }
        public Dollar GetDollarByID(int id)
        {
            return allDollars.Find(t => t.ID == id);
        }
        public List<string> GetInstructor()
        {
            var mainItems = (from key in DollarData.Descendants("instructor") select key.Value).Distinct().ToList();
            return mainItems.ToList();
        }
    }

}