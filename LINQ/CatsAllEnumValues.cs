using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public enum MyEnum
    {
        Enum_Value_A, Enum_Value_B, Enum_Value_C, Enum_Value_D
    }

    public static class CatsAllEnumValues
    {
        public static void Run()
        {
            Console.WriteLine("\r\n Foreach Enum values : \r\n");

            IEnumerable<MyEnum> myEnums = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>();

            foreach (var item in myEnums)
            {
                Console.WriteLine((int)item + " - " + item.ToString());
            }
        }
    }
}
