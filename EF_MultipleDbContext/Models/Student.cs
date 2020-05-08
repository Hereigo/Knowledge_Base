using System;

namespace EF_MultipleDbContext.Models
{
    public class Student : Teacher
    {
        public static Student GenerateOne()
        {
            RandomStringGenerator generator = new RandomStringGenerator();

            return new Student
            {
                FirstMidName = generator.GetWord(),
                LastName = generator.GetWord(),
                StartDate = DateTime.Now
            };
        }
    }
}
