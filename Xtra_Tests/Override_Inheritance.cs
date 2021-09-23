using System;

namespace Xtra_Tests
{
    internal static class Override_Inheritance
    {
        class A
        {
            public virtual void Print()
            {
                Console.WriteLine(" A ");
            }
        }

        class B : A
        {
            public override void Print()
            {
                Console.WriteLine(" B ");
            }
        }

        class C : B
        {
            public new void Print()
            {
                base.Print();
                Console.WriteLine(" C ");
            }
        }

        internal static void Test()
        {
            A a = new A();
            A b = new B();
            A c = new C();

            a.Print();
            b.Print();
            c.Print();
        }
    }
}
