using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    using EventModels;

    public class ParkRepository : GenericRepository<Park>
    {
        public ParkRepository(ParkDBContext db) : base(db)
        {
        }

        public Park FindByName(string parkName)
        {
            if (parkName == null) throw new ArgumentNullException("parkName");

            var p = (from prks in this.db.Parks
                     where prks.Name.ToUpper() == parkName.ToUpper()
                     select prks).FirstOrDefault();
            return p;
        }

        public Park FindByShortName(string parkCode)
        {
            if (parkCode == null) throw new ArgumentNullException("parkCode");

            var p = (from prks in this.db.Parks
                     where prks.ShortName.ToUpper() == parkCode.ToUpper()
                     select prks).FirstOrDefault();
            return p;
        }
    }
}
