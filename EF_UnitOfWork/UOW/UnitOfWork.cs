using System;

namespace EF_UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext db = new DatabaseContext();

        private RepositoryA GetRepoA { get; }
        private RepositoryB GetRepoB { get; }

        public RepositoryA OneRepository
        {
            get
            {
                return GetRepoA ?? new RepositoryA(db);
            }
        }

        public RepositoryB TwoRepository
        {
            get
            {
                return GetRepoB ?? new RepositoryB(db);
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
