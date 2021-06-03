namespace Mediator_Use
{
    class AnMediator : AbsMediator
    {
        public CustomerColleague Colleague1 { get; set; }

        public ProgrammerColleague Colleague2 { get; set; }

        public override void Send(string msg, AbsColleague colleague)
        {
            if (Colleague1 == colleague)
                Colleague2.Notify(msg);
            else
                Colleague1.Notify(msg);
        }
    }
}
