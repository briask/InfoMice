using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkViewer.Models
{
    public class WDWDay
    {
        public int Id { get; set; }

        public string ParkName { get; set; }

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
    }
}