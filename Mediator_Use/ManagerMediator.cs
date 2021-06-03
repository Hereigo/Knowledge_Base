namespace Mediator_Use
{
    internal class ManagerMediator : AbsMediator
    {
        public AbsColleague Customer { get; set; }

        public AbsColleague Programmer { get; set; }

        public AbsColleague Tester { get; set; }

        public override void Send(string msg, AbsColleague colleague)
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
