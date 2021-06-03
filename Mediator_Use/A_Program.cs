using System;

namespace Mediator_Use
{
    static class A_Program
    {
        static void Main()
        {
            ManagerMediator mediator = new ManagerMediator();

            AbsColleague customer = new CustomerColleague(mediator);

            AbsColleague programmer = new ProgrammerColleague(mediator);

            AbsColleague tester = new TesterColleague(mediator);

            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;

            customer.Send("I need an application.");

            programmer.Send("I've created the App. Test it.");

            tester.Send("The App is created and tested.");

            Console.Read();
        }
    }
}
