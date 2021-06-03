using System;

namespace Mediator_Use
{
    class TesterColleague : AbsColleague
    {
        public TesterColleague(AbsMediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message for Tester : " + message);
        }
    }
}
