using System.Collections.Generic;

namespace EF_UnitOfWork.UOW
{
    public class RepositoryA : IRepository<EntityA>
    {
        private DatabaseContext _db;

        public RepositoryA(DatabaseContext db)
        {
            _db = db;
        }

        public IEnumerable<EntityA> GetAll()
        {
            return _db.EntityA;
        }

        public EntityA Get(int id)
        {
            return _db.EntityA.Find(id);
        }

        public void Create(EntityA entity)
        {
            _db.EntityA.Add(entity);
        }
    }
}
