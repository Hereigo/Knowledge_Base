using System;

namespace Mediator_Use
{
    internal class ProgrammerColleague : AbstractPerson
    {
        public ProgrammerColleague(AbstractMediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message for Programmer : " + message);
        }
    }
}
