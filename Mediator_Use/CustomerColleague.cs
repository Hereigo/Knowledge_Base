using System;

namespace Mediator_Use
{
    internal class CustomerColleague : AbsColleague
    {
        public CustomerColleague(AbsMediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message for Customer : " + message);
        }
    }
}
