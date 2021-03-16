namespace DI_Service_Lifetimes
{
    public interface IService
    {
        void Info();
    }

    public interface IScopedSvc : IService { }
    public interface ISingletonSvc : IService { }
    public interface ITransientSvc : IService { }
}
