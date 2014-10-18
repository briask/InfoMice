using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoMice.Repositories
{
    using System.Data.Entity;
    using Models;

    public class AcroymnRepository : Repository<Acronym>
    {
        public AcroymnRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}