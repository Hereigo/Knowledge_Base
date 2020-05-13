using System;

namespace EF_Repository_UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        int Complete();
        int Complete(bool usingTransaction);
        IUnitOfWork New();
    }
}
