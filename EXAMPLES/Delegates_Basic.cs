namespace Xtra_Tests
{
    // 2. - Declare (create) Delegate-Type for our method.
    delegate void MyDelegateType(int number);

    public static class Delegates_Basic
    {
        // 1. - Get some method(s).
        static void SomeMethod1(int num)
        {
            System.Console.WriteLine($"Method 1 result - {num}.");
        }

        static void SomeMethod2(int num)
        {
            System.Console.WriteLine($"Method 2 result - {num}.");
        }

        // 3. - Use Our Delegate-Type.
        public static void Test()
        {
            // 4. - Binding Delegate-Type to the appropriate Delegate.
            var instanceOfMyDelegateType = new MyDelegateType(SomeMethod1);

            instanceOfMyDelegateType.Invoke(111);

            System.Console.WriteLine("Summary of both :");

            // 5. - Add one another.
            instanceOfMyDelegateType += new MyDelegateType(SomeMethod2);

            // 6. Executing.
            instanceOfMyDelegateType.Invoke(222);
        }
    }
}
