using System;

namespace OOP_Deriving
{
    public static class Use_Base
    {
        public abstract class ParentAbstract
        {
            public virtual void Method()
            {
                Console.WriteLine("Virtual Method In Abstract Parent.");
            }
        }

        public class ChildClass : ParentAbstract
        {
            public override void Method()
            {
                Console.WriteLine("Call - base.Method() : ");

                base.Method();

                // this.Method(); - will call infinite recursion

                Console.WriteLine();

                Console.WriteLine("Overriden Method In Child Class.");
            }
        }

        public static void Test()
        {
            ParentAbstract item = new ChildClass();

            item.Method();
        }
    }
}
