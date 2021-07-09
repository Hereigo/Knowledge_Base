using System.Collections.Generic;

namespace EF_UnitOfWork
{
    public class RepositoryB : IRepository<EntityB>
    {
        private DatabaseContext _db;

        public RepositoryB(DatabaseContext db)
        {
            _db = db;
        }

        public IEnumerable<EntityB> GetAll()
        {
            return _db.EntityB;
        }

        public EntityB Get(int id)
        {
            return _db.EntityB.Find(id);
        }

        public void Create(EntityB entity)
        {
            _db.EntityB.Add(entity);
        }
    }
}
