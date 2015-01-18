using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventModels
{
    public class Park
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<ParkOperatingHours> OperatingHours { get; set; }
    }
}
