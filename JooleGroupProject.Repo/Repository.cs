using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JooleGroupProject.Data;


namespace JooleGroupProject.Repo
{
    public class Repository<T> where T : class
    {
        public JooleAppDBEntities context;
        public DbSet<T> entities;

        public Repository()
        {
            this.context = new JooleAppDBEntities();
            this.entities = context.Set<T>();
        }

        public T Get(int id)
        {
            return this.entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.entities;
        }

        public void Insert(T entity)
        {
            this.entities.Add(entity);
            this.context.SaveChanges();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

    }
}
