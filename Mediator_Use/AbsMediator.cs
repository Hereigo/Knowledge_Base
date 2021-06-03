namespace Mediator_Use
{
    abstract class AbsMediator
    {
        public abstract void Send(string msg, AbsColleague colleague);
    }
}
