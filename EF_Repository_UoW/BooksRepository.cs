using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Repository_UoW
{
    public class BooksRepository : IRepository<BookAndroid>
    {
        private readonly OrderContext db;

        public BooksRepository(OrderContext context)
        {
            db = context;
        }

        public IEnumerable<BookAndroid> GetAll()
        {
            return db.Books;
        }

        public BookAndroid Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(BookAndroid book)
        {
            db.Books.Add(book);
        }

        public void Update(BookAndroid book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
    }
}
