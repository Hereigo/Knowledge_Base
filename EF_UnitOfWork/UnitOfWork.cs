using System;

namespace EF_UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext db = new DatabaseContext();

        private EntityOneRepository GetEntityOneRepo { get; }
        private EntityTwoRepository GetEntityTwoRepo { get; }

        public EntityOneRepository OneRepository
        {
            get
            {
                return GetEntityOneRepo ?? new EntityOneRepository(db);
            }
        }

        public EntityTwoRepository TwoRepository
        {
            get
            {
                return GetEntityTwoRepo ?? new EntityTwoRepository(db);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

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
