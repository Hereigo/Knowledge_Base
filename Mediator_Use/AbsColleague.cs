namespace Mediator_Use
{
    abstract class AbsColleague
    {
        protected AbsMediator mediator;

        protected AbsColleague(AbsMediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
}
