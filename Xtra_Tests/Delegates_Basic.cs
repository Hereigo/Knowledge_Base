namespace Xtra_Tests
{
    public static class Delegates_Basic
    {
        // 1. - Get some method(s).
        static string SomeMethod1(int num)
        {
            return $"Method 1 result - {num}.";
        }

        static string SomeMethod2(int num)
        {
            return $"Method 2 result - {num}.";
        }

        // 2. - Declare (create) Delegate-Type for our method.
        delegate string MyDelegateType(int number);

        // 3. - Use Our Delegate-Type.
        public static void Test()
        {
            // 4. - Binding Delegate-Type to the appropriate Delegate.
            var instanceOfMyDelegateType = new MyDelegateType(SomeMethod1);

            // 5. - Rebinding (owerriding).
            instanceOfMyDelegateType += new MyDelegateType(SomeMethod2);

            // 6. Executing
            var result2 = instanceOfMyDelegateType.Invoke(77777);

            System.Console.WriteLine(result2);

            // 7. Multicast Delegate :

            var instanceTwoOfMyDelegateType = new MyDelegateType(SomeMethod2);

            var multicast = instanceOfMyDelegateType + instanceTwoOfMyDelegateType;

            var result3 = multicast.Invoke(88888);

            System.Console.WriteLine("Summary of both :");
            System.Console.WriteLine(result3);

            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/how-to-combine-delegates-multicast-delegates

        }
    }
}
