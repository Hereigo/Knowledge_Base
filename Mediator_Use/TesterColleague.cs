using System;

namespace Mediator_Use
{
    internal class TesterColleague : AbstractPerson
    {
        public TesterColleague(AbstractMediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message for Tester : " + message);
        }
    }
}
