namespace Mediator_Use
{
    internal class AnMediator : AbstractMediator
    {
        public CustomerColleague Colleague1 { get; set; }

        public ProgrammerColleague Colleague2 { get; set; }

        public override void Send(string msg, AbstractPerson colleague)
        {
            if (Colleague1 == colleague)
                Colleague2.Notify(msg);
            else
                Colleague1.Notify(msg);
        }
    }
}
