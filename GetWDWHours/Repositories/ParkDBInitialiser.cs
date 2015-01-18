using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    using System.Data.Entity;
    using EventModels;

    public class ParkDBInitialiser : CreateDatabaseIfNotExists<ParkDBContext>
    {
        protected override void Seed(ParkDBContext context)
        {
            SeedParks(context);

            base.Seed(context);
        }

        private static void SeedParks(ParkDBContext context)
        {
            List<Park> allParks = new List<Park>();

            allParks.Add(new Park {Name = "Magic Kingdom", ShortName = "WDWMK"});
            allParks.Add(new Park {Name = "Epcot - Future World", ShortName = "WDWEPFW"});
            allParks.Add(new Park { Name = "Epcot - World Showcase", ShortName = "WDWEPWS" });
            allParks.Add(new Park { Name = "Disney Hollywood Studios", ShortName = "WDWHS" });
            allParks.Add(new Park { Name = "Disney Animal Kingdom", ShortName = "WDWAK" });
            allParks.Add(new Park { Name = "Disney Typhoon Lagoon Water Park", ShortName = "WDWTL" });
            allParks.Add(new Park { Name = "Disney Blizzard Beach Water Park", ShortName = "WDWBB" });
            allParks.Add(new Park { Name = "Downtown Disney Marketplace", ShortName = "WDWDDMP" });
            allParks.Add(new Park { Name = "Downtown Disney West Side", ShortName = "WDWDDWS" });
            allParks.Add(new Park { Name = "Downtown Disney Pleasure Island", ShortName = "WDWDDPI" });
            allParks.Add(new Park { Name = "ESPN Wide World of Sports Complex", ShortName = "WDWESPN" });
            allParks.Add(new Park { Name = "Downtown Disney Area", ShortName = "WDWDD" });

            foreach (var park in allParks)
            {
                context.Parks.Add(park);
            }
        }
    }
}
