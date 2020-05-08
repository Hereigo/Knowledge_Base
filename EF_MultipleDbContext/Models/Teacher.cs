using System;

namespace EF_MultipleDbContext.Models
{
    public class Teacher : IPerson
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsTeacher { get; set; }

        public static Teacher GenerateOne()
        {
            RandomStringGenerator generator = new RandomStringGenerator();

            return new Teacher
            {
                FirstMidName = generator.GetWord(),
                LastName = generator.GetWord(),
                StartDate = DateTime.Now
            };
        }
    }
}
