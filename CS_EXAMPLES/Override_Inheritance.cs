using System;

namespace CS_EXAMPLES
{
    internal static class Override_Inheritance
    {
        class A
        {
            public virtual void Print() { Console.WriteLine(" A "); }
        }

        class B : A
        {
            public override void Print() { Console.WriteLine(" B "); }
        }

        class C : B
        {
            // Will Not Call for (A\B = new C();) - Overriden!
            public new void Print() { Console.WriteLine(" C "); }
        }

        internal static void Test()
        {
            A aa = new A(); // A
            A ab = new B(); // B
            A ac = new C(); // B
            B bb = new B(); // B
            B bc = new C(); // B
            C cc = new C(); // C

            aa.Print();
            ab.Print();
            ac.Print(); 
            bb.Print();
            bc.Print();
            cc.Print();
        }
    }
}
