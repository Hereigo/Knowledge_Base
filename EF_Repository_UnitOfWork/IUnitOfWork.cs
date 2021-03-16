namespace EF_Repository_UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Author> AuthorRepository { get; }

        IRepository<Book> BookRepository { get; }

        void Commit();

        // Discards all changes that has not been commited
        void RejectChanges();

        void Dispose();
    }
}
