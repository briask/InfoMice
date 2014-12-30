using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    using System.Data.Entity;

    public class GenericRepository<T> : IRepository<T> where T:class 
    {
        public ParkDBContext db { get; private set; }

        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new ParkDBContext();
            table = db.Set<T>();
        }

        public GenericRepository(ParkDBContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
