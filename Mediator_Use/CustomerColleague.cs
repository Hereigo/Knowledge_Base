using System;

namespace Mediator_Use
{
    internal class CustomerColleague : AbstractPerson
    {
        public CustomerColleague(AbstractMediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message for Customer : " + message);
        }
    }
}
