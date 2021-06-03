namespace Mediator_Use
{
    abstract class AbstractMediator
    {
        public abstract void Send(string msg, AbstractPerson colleague);
    }
}
