using System;

namespace Mediator_Use
{
    internal class ProgrammerColleague : AbsColleague
    {
        public ProgrammerColleague(AbsMediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message for Programmer : " + message);
        }
    }
}
