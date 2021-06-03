namespace Mediator_Use
{
    internal class ManagerMediator : AbstractMediator
    {
        public AbstractPerson Customer { get; set; }

        public AbstractPerson Programmer { get; set; }

        public AbstractPerson Tester { get; set; }

        public override void Send(string msg, AbstractPerson colleague)
        {
            // Message from Customer to Programmer :

            if (Customer == colleague)
                Programmer.Notify(msg);

            // Message from Programmer to Tester :

            else if (Programmer == colleague)
                Tester.Notify(msg);

            // Message from Tester to Customer :

            else if (Tester == colleague)
                Customer.Notify(msg);
        }
    }
}
