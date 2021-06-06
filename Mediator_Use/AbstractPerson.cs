namespace Mediator_Use
{
    abstract class AbstractPerson
    {
        protected AbstractMediator mediator;

        protected AbstractPerson(AbstractMediator mediator)
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
