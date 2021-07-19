using System;

namespace EF_Repository_UoW
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        private readonly OrderContext db = new OrderContext();
        private readonly BooksRepository bookRepository;
        private readonly OrdersRepository orderRepository;

        public BooksRepository Books
        {
            get { return bookRepository ?? new BooksRepository(db); }
        }

        public OrdersRepository Orders
        {
            get { return orderRepository ?? new OrdersRepository(db); }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
