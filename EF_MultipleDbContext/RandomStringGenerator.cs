using System;

namespace EF_MultipleDbContext
{
    public class RandomStringGenerator
    {
        Random rand = new Random();

        public string GetWord()
        {
            char[] upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            char[] lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();



            int stringLenth = rand.Next(3, 10);

            // First letter in UpperCase (my current case necessary)
            // Should be configured in the future.
            int firstLetter = rand.Next(0, upperCaseLetters.Length - 1);

            string word = upperCaseLetters[firstLetter].ToString();

            for (int i = 1; i <= stringLenth; i++)
            {
                int letter_num = rand.Next(0, lowerCaseLetters.Length - 1);

                word += lowerCaseLetters[letter_num];
            }

            return word;
        }
    }
}
