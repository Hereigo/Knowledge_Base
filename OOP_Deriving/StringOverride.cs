using System;

namespace OOP_Deriving
{
    public class StringOverride
    {
        public readonly string test;

        public StringOverride(string testName)
        {
            if (string.IsNullOrEmpty(testName))
            {
                throw new ArgumentException("Invalid Test Name!");
            }

            test = testName;
        }

        public override string ToString()
        {
            return $"{nameof(test)} : {test}";
        }
    }
}
