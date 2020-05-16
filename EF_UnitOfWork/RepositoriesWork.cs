using System.Collections.Generic;
namespace EF_UnitOfWork
{
    public class EntityOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
    }

    public class EntityOneRepository : IRepository<EntityOne>
    {
        private DatabaseContext db;

        public EntityOneRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<EntityOne> GetAll()
        {
            return db.EntityOne;
        }

        public EntityOne Get(int id)
        {
            return db.EntityOne.Find(id);
        }

        public void Create(EntityOne entity)
        {
            db.EntityOne.Add(entity);
        }
    }

    // Another Repositories and Entities :

    public class EntityTwoRepository : IRepository<EntityTwo>
    {
        private DatabaseContext db;

        public EntityTwoRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(EntityTwo item)
        {
            throw new System.NotImplementedException();
        }

        public EntityTwo Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EntityTwo> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }

    public class EntityTwo
    {
    }
}
