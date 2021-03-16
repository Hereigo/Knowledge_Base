using System;

namespace DI_Service_Lifetimes
{
    public abstract class OperationAbs : ISingletonSvc, IScopedSvc, ITransientSvc
    {
        private Guid _operationId;
        private readonly string _lifeTime;

        protected OperationAbs(string lifeTime)
        {
            _operationId = Guid.NewGuid();
            _lifeTime = lifeTime;

            Console.WriteLine($"{_lifeTime} Service Created.");
        }

        public void Info()
        {
            Console.WriteLine($"{_lifeTime}: {_operationId}");
        }
    }
}
