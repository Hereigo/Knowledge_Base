using System;

namespace CommonHelper
{
    public static class FakeNameGenerator
    {
        private const byte MaxLength = 10;
        private const byte MinLength = 4;
        private static readonly Random rand = new Random();

        public static string GetName(int minLength = MinLength, int maxLength = MaxLength, bool isFirstLetterUpper = true)
        {
            string generatedName = string.Empty;

            int stringLenth = rand.Next(minLength, maxLength);

            char[] upperCaseLetters = "ABCDEFGHIJKAELMNOPQRISTUVUWXYZY".ToCharArray();
            char[] lowerCaseLetters = "abcdefghijkaelmnopqristuvuwxyzy".ToCharArray();

            if (isFirstLetterUpper)
            {
                generatedName +=
                    upperCaseLetters[rand.Next(0, upperCaseLetters.Length - 1)]
                    .ToString();
            }

            for (int i = 1; i <= stringLenth; i++)
            {
                generatedName +=
                    lowerCaseLetters[rand.Next(0, lowerCaseLetters.Length - 1)];
            }

            return generatedName;
        }
    }
}
