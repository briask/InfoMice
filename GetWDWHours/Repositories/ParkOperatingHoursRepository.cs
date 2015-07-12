using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    using EventModels;

    public class ParkOperatingHoursRepository : GenericRepository<ParkOperatingHours>
    {
        public ParkOperatingHoursRepository(ParkDBContext db)
            : base(db)
        {
        }

        public List<ParkOperatingHours> GetAllForMonth(int monthNumber)
        {
            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentOutOfRangeException("monthNumber");
            }

            DateTime monthStart = DateTime.Now;

            if (monthNumber < DateTime.Now.Month)
            {
                DateTime nextYear = DateTime.Now.AddYears(1);
                monthStart = new DateTime(nextYear.Month, monthNumber, 1);
            }
            else
            {
                monthStart = new DateTime(DateTime.Now.Year, monthNumber, 1);
            }

            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var parkhours = GetAllParkHours(monthStart, monthEnd);

            return parkhours;
        }

        public List<ParkOperatingHours> GetAllParkHours(DateTime startDate, DateTime endDate)
        {
            if (startDate == null || endDate == null)
            {
                return new List<ParkOperatingHours>();
            }

            var allHours = from poh in this.db.ParkOperatingHours
                           where poh.ParkDate >= startDate && poh.ParkDate <= endDate
                           group poh by new { poh.ParkDate, poh.ParkId } into g
                           select g.OrderByDescending(a => a.Updated).FirstOrDefault();
                           
            foreach (var park in allHours)
            {
                if (park.NormalOpen == null || park.NormalClose == null)
                {
                    park.NormalOpen = park.ParkDate;
                    park.NormalClose = park.ParkDate;
                    park.Park.Name = park.Park.Name + " Closed";
                }
            }

            return allHours.ToList();
        }
    }
}
