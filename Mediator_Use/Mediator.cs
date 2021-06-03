namespace Mediator_Use
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
}
