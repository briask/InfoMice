using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetWDWHours
{
    using HtmlAgilityPack;

    class Program
    {
        static void Main(string[] args)
        {
            WDWHoursSite test = new WDWHoursSite();

            DateTime dateToRetrieve = new DateTime(2015, 1, 4);
            string url = test.GenerateURL(dateToRetrieve);
            var page = test.GetPage(url);
            //var page = test.GetPage("https://disneyworld.disney.go.com/calendars/2014-12-30/");

            var testhours = test.GetMagicKingdomHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetEpcotFutureWorldHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetEpcotWorldShowcaseHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetDisneyHollywoodStudioHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetAnimalKingdomHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetTyphoonLagoonHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetBlizzardBeachHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetDowntownDisneyMarketPlacehHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetDowntownDisneyWestSideHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetDowntownDisneyPleasureIslandHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetESPNHours(page).AdjustForDate(dateToRetrieve);
            testhours = test.GetDowntownDisneyHours(page).AdjustForDate(dateToRetrieve);
        }
    }
}
