using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace GetWDWHours
{
    using System.Globalization;
    using System.Net;
    using System.Text.RegularExpressions;
    using EventModels;

    class WDWHoursSite
    {
        public HtmlDocument GetPage(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            try
            {
                var client = new HtmlWeb();
                var page = client.Load(url);

                return page;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckIfDataValid(HtmlDocument page)
        {
            if (page.DocumentNode.SelectSingleNode(
                "/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[1]/div[1]/div[2]") == null)
            {
                return false;
            }
            else if (page.DocumentNode.SelectSingleNode(
                        "/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[1]/div[1]/div[2]")
                        .InnerHtml == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
        }

        public ParkOperatingHours GetMagicKingdomHours(HtmlDocument page)
        {

            var mk = new ParkOperatingHours();

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[1]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[1]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours mkHours = GetOperatingHours(normalParkHours, magicParkHours);

            return mkHours;
        }

        public ParkOperatingHours GetEpcotFutureWorldHours(HtmlDocument page)
        {
            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[2]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[2]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours epcotFutureHours = GetOperatingHours(normalParkHours, magicParkHours);

            return epcotFutureHours;
        }

        public ParkOperatingHours GetEpcotWorldShowcaseHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[3]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[3]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours epcotWorldHours = GetOperatingHours(normalParkHours, magicParkHours);

            return epcotWorldHours;
        }

        public ParkOperatingHours GetDisneyHollywoodStudioHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[4]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[4]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours dhsHours = GetOperatingHours(normalParkHours, magicParkHours);

            return dhsHours;
        }

        public ParkOperatingHours GetAnimalKingdomHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[5]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[5]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours akHours = GetOperatingHours(normalParkHours, magicParkHours);

            return akHours;
        }

        public ParkOperatingHours GetTyphoonLagoonHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[6]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[6]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours typhoonHours = GetOperatingHours(normalParkHours, magicParkHours);

            return typhoonHours;
        }


        public ParkOperatingHours GetBlizzardBeachHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[7]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[7]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours blizzardHours = GetOperatingHours(normalParkHours, magicParkHours);

            return blizzardHours;
        }

        public ParkOperatingHours GetDowntownDisneyMarketPlacehHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[8]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[8]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours mkplaceHours = GetOperatingHours(normalParkHours, magicParkHours);

            return mkplaceHours;
        }

        public ParkOperatingHours GetDowntownDisneyWestSideHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[9]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[9]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours westsideHours = GetOperatingHours(normalParkHours, magicParkHours);

            return westsideHours;
        }

        public ParkOperatingHours GetDowntownDisneyPleasureIslandHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[10]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[10]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours pleasureIslandHours = GetOperatingHours(normalParkHours, magicParkHours);

            return pleasureIslandHours;
        }

        public ParkOperatingHours GetESPNHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[11]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[11]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours espnHours = GetOperatingHours(normalParkHours, magicParkHours);

            return espnHours;
        }

        public ParkOperatingHours GetDowntownDisneyHours(HtmlDocument page)
        {

            var normalParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[12]/div[1]/div[2]").InnerHtml;
            var magicParkHours = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[4]/div[1]/div[2]/div[2]/div[2]/a[12]/div[1]/div[3]").InnerHtml;

            ParkOperatingHours downtownHours = GetOperatingHours(normalParkHours, magicParkHours);

            return downtownHours;
        }

        private ParkOperatingHours GetOperatingHours(string openTime, string closeTime, string magicHours)
        {
            var opHours = new ParkOperatingHours();
            var nHours = new List<DateTime>();
            var mHours = new List<DateTime>();

            opHours.ParkActive = true;

            if (magicHours.Contains("noHours"))
            {
                opHours.HasExtraHours = false;
            }
            else
            {
                opHours.HasExtraHours = true;
                mHours = GetHoursByParagraph(magicHours);
            }

            opHours.NormalOpen = Convert.ToDateTime(openTime);
            opHours.NormalClose = Convert.ToDateTime(closeTime);

            if (opHours.HasExtraHours == true)
            {
                if (mHours[0].Hour < 12)
                {
                    opHours.EarlyOpen = mHours[0];
                    opHours.EarlyClose = mHours[1];
                }
                else
                {
                    opHours.LateOpen = mHours[0];
                    opHours.LateClose = mHours[1];
                }

                if (mHours.Count() > 2)
                {
                    opHours.LateOpen = mHours[2];
                    opHours.LateClose = mHours[3];
                }
            }
            
            return opHours;
        }

        private ParkOperatingHours GetOperatingHours(string normalHours, string magicHours)
        {
            // <p>7:00am &ndash; 8:00am</p><p>1:00am &ndash; 3:00am</p>
            // 9:30 pm to 11:30 pm &ndash; Extra Magic Hours

            try
            {
                var opHours = new ParkOperatingHours();

                var nHours = new List<DateTime>();
                var mHours = new List<DateTime>();
                var cDates = new List<DateTime>();

                if (normalHours.Contains("Closed"))
                {
                    opHours.ParkActive = false;
                    cDates = GetClosedDates(normalHours);

                    opHours.ParkClosed = cDates[0];
                    opHours.ParkReopen = cDates[1];

                    return opHours;
                }
                else
                {
                    opHours.ParkActive = true;
                }

                if (opHours.ParkActive)
                {
                    if (normalHours.Contains("Extra Magic Hours"))
                    {
                        nHours = GetHoursByTxt(normalHours);
                    }
                    else
                    {
                        if (normalHours.Contains("<p>"))
                        {
                            nHours = GetHoursByParagraph(normalHours);
                        }
                    }

                    if (magicHours.Contains("noHours"))
                    {
                        opHours.HasExtraHours = false;
                    }
                    else if (magicHours.Contains("Extra Magic Hours"))
                    {
                        mHours = GetHoursByTxt(magicHours);
                        opHours.HasExtraHours = true;
                    }
                    else
                    {
                        if (normalHours.Contains("<p>"))
                        {
                            mHours = GetHoursByParagraph(magicHours);
                            opHours.HasExtraHours = true;
                        }
                    }
                    opHours.NormalOpen = nHours[0];
                    opHours.NormalClose = nHours[1];

                    if (opHours.ParkActive == false)
                    {
                        opHours.ParkClosed = cDates[0];
                        opHours.ParkReopen = cDates[1];
                    }

                    if (opHours.HasExtraHours == true)
                    {
                        if (mHours[0].Hour < 12)
                        {
                            opHours.EarlyOpen = mHours[0];
                            opHours.EarlyClose = mHours[1];
                        }
                        else
                        {
                            opHours.LateOpen = mHours[0];
                            opHours.LateClose = mHours[1];
                        }
                    }
                }

                return opHours;

            }
            catch (Exception)
            {
                return new ParkOperatingHours();
            }
        }

        private List<DateTime> GetClosedDates(string normalHours)
        {
            if (normalHours == null) throw new ArgumentNullException("normalHours");
            //Closed from Oct 26 &ndash; Jan 03
            try
            {
                var s1 = Regex.Replace(normalHours, " &ndash", string.Empty);
                var s2 = Regex.Replace(s1, "Closed from", string.Empty);

                var cDates = Regex.Split(s2, ";");
                CultureInfo culture = new CultureInfo("en-US");
                List<DateTime> closureDates = new List<DateTime>();
                closureDates.Add(Convert.ToDateTime(cDates[0], culture));
                closureDates.Add(Convert.ToDateTime(cDates[1], culture));

                return closureDates;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<DateTime> GetHoursByTxt(string normalHours)
        {
            // 9:30 pm to 11:30 pm &ndash; Extra Magic Hours

            var locSemi = normalHours.IndexOf(';');
            var s1 = normalHours.Substring(0, locSemi);

            var s2 = Regex.Replace(s1, " &ndash", string.Empty);
            var times = Regex.Split(s2, "to");

            var returnTimes = new List<DateTime> { Convert.ToDateTime(times[0]), Convert.ToDateTime(times[1]) };

            return returnTimes;
        }

        private static List<DateTime> GetHoursByParagraph(string hours)
        {
            // <p>7:00am &ndash; 8:00am</p><p>1:00am &ndash; 3:00am</p>
            var times = Regex.Split(hours, "</p>");

            var s1 = Regex.Replace(times[0], "<p>", string.Empty);
            s1 = Regex.Replace(s1, "&ndash;", string.Empty);

            var mhTimes = Regex.Split(s1, " ");

            var opHours = new List<DateTime>();
            opHours.Add(Convert.ToDateTime(mhTimes[0]));
            opHours.Add(Convert.ToDateTime(mhTimes[2]));

            if (times.Count() > 2)
            {
                var s2 = Regex.Replace(times[1], "<p>", string.Empty);
                s2 = Regex.Replace(s2, "&ndash;", string.Empty);

                mhTimes = Regex.Split(s2, " ");

                opHours.Add(Convert.ToDateTime(mhTimes[0]));
                opHours.Add(Convert.ToDateTime(mhTimes[2]));
            }

            return opHours;
        }

        public string GenerateURL(DateTime theDay)
        {
            // https://disneyworld.disney.go.com/calendars/2014-12-30/

            string url = string.Format("https://disneyworld.disney.go.com/calendars/{0}-{1}-{2}/", theDay.Year, theDay.Month.ToString("D2"), theDay.Day.ToString("D2"));

            return url;
        }
    }
}
