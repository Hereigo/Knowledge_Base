using System;
using System.Collections.Generic;

namespace OOP_Deriving
{
    internal static class HashSet_use
    {
        internal static void Test()
        {
            var hashSet = new HashSet<KeyValuePair<int, int>>();

            hashSet.Add(new KeyValuePair<int, int>(1, 2));
            hashSet.Add(new KeyValuePair<int, int>(2, 1));
            hashSet.Add(new KeyValuePair<int, int>(1, 2));

            foreach (var item in hashSet)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

            // How to check if Contains :

            if (hashSet.Contains(new KeyValuePair<int, int>(1, 2)))
            {
                Console.WriteLine("hashSet.Contains(new KeyValuePair<int, int>(1, 2)");
            }
        }
    }
}