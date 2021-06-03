using System;

namespace Mediator_Use
{
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }
}
