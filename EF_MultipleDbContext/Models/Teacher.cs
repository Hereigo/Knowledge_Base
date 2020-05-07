namespace EF_MultipleDbContext.Models
{
    public class Teacher : IPerson
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public System.DateTime StartDate { get; set; }
        public bool IsTeacher { get; set; }
    }
}
