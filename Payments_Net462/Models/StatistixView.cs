using System.ComponentModel;

namespace Payments_Net462.Models
{
    public class StatistixView
    {
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("Curr.Month")]
        public int CurrentMonth { get; set; }

        [DisplayName("Prev.Month")]
        public int PreviousMonth { get; set; }

        [DisplayName("Avg.Year")]
        public int YearAverage { get; set; }
    }
}