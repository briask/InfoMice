using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWDWHours
{
    using System.Threading;
    using EventModels;
    using HtmlAgilityPack;
    using Repositories;

    class Program
    {
        static void Main(string[] args)
        {
            WDWHoursSite test = new WDWHoursSite();

            //DateTime dateToRetrieve = new DateTime(2015, 1, 4);
            //string url = test.GenerateURL(dateToRetrieve);
            //var page = test.GetPage(url);
            ////var page = test.GetPage("https://disneyworld.disney.go.com/calendars/2014-12-30/");
            

            var myctxt = new ParkDBContext();

            var dbquery = new ParkRepository(myctxt);

            DateTime startdate = DateTime.Today;

            DateTime enddate = DateTime.Today.AddDays(180);

            List<DateTime> datesToQuery = GenerateDatesToQuery(startdate, 180).ToList();

            using (myctxt)
            {
                foreach (var dateToRetrieve in datesToQuery)
                {
                    string url = test.GenerateURL(dateToRetrieve);
                    var page = test.GetPage(url);

                    while(test.CheckIfDataValid(page) == false)
                    {
                        Thread.Sleep(5000);
                        page = test.GetPage(url);
                    }

                    var testhours = test.GetMagicKingdomHours(page).AdjustForDate(dateToRetrieve);

                    var mkpk = dbquery.FindByShortName("WDWMK");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetEpcotFutureWorldHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWEPFW");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetEpcotWorldShowcaseHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWEPWS");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetDisneyHollywoodStudioHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWHS");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetAnimalKingdomHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWAK");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetTyphoonLagoonHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWTL");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetBlizzardBeachHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWBB");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetDowntownDisneyMarketPlacehHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWDDMP");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetDowntownDisneyWestSideHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWDDWS");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetDowntownDisneyPleasureIslandHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWDDPI");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetESPNHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWESPN");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    testhours = test.GetDowntownDisneyHours(page).AdjustForDate(dateToRetrieve);
                    mkpk = dbquery.FindByShortName("WDWDD");
                    testhours.ParkId = mkpk.Id;
                    myctxt.ParkOperatingHours.Add(testhours);

                    myctxt.SaveChanges();

                    Thread.Sleep(1000);
                }
            }
        }

        private static IEnumerable<DateTime> GenerateDatesToQuery(DateTime startdate, DateTime enddate)
        {
            for (var day = startdate.Date; day.Date <= enddate.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }

        private static IEnumerable<DateTime> GenerateDatesToQuery(DateTime startdate, int numDates)
        {
            for (var day = startdate.Date; day.Date <= startdate.AddDays(numDates); day = day.AddDays(1))
            {
                yield return day;
            }
        }
    }
}
