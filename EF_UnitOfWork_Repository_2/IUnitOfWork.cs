namespace EF_UnitOfWork_Repository_2
{
    public interface IUnitOfWork
    {
        IRepository<BizOneEntity> RepositoryOne { get; }

        IRepository<BizTwoEntity> RepositoryTwo { get; }

        void Commit();

        // Discards all changes that has not been commited
        void RejectChanges();

        void Dispose();
    }
}
