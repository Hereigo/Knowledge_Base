using System.Collections.Generic;

namespace EF_Repository_UoW
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
    }
}
