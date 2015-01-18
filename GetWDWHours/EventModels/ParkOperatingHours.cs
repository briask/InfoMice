using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventModels
{
    public class ParkOperatingHours
    {
        public int Id { get; set; }

        public DateTime ParkDate { get; set; }

        public bool ParkActive { get; set; }

        public bool HasExtraHours { get; set; }

        public DateTime? ParkClosed { get; set; }

        public DateTime? ParkReopen { get; set; }

        public DateTime? NormalOpen { get; set; }

        public DateTime? NormalClose { get; set; }

        public DateTime? EarlyOpen { get; set; }

        public DateTime? EarlyClose { get; set; }

        public DateTime? LateOpen { get; set; }

        public DateTime? LateClose { get; set; }

        public DateTime Updated { get; set; }

        public int ParkId {get; set;}

        public virtual Park Park { get; set; }

        public ParkOperatingHours AdjustForDate(DateTime theDate)
        {
            if (ParkClosed > ParkReopen)
            {
                ParkReopen = ParkReopen.Value.AddYears(1);
            }

            if (NormalOpen > NormalClose)
            {
                NormalClose = NormalClose.Value.AddDays(1);
            }

            if (EarlyOpen > EarlyClose)
            {
                EarlyClose = EarlyClose.Value.AddDays(1);
            }

            if (LateOpen > LateClose)
            {
                LateClose = LateClose.Value.AddDays(1);
            }

            this.ParkDate = theDate.Date;

            this.NormalOpen = theDate.Date + (this.NormalOpen - DateTime.Today);
            this.NormalClose = theDate.Date + (this.NormalClose - DateTime.Today);

            this.EarlyOpen = theDate.Date + (this.EarlyOpen - DateTime.Today);
            this.EarlyClose = theDate.Date + (this.EarlyClose - DateTime.Today);

            this.LateOpen = theDate.Date + (this.LateOpen - DateTime.Today);
            this.LateClose = theDate.Date + (this.LateClose - DateTime.Today);

            this.Updated = DateTime.Now;
            return this;
        }
    }}
