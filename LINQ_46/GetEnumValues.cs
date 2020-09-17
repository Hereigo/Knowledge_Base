using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_46
{
    public enum MyEnum
    {
        EnumA, EnumB, EnumC, EnumD
    }

    class GetEnumValues
    {
        IEnumerable<MyEnum> test = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>();
    }
}
