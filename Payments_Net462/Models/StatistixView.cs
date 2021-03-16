using System.ComponentModel;

namespace Payments_Net462.Models
{
    public class StatistixView
    {
        [DisplayName("Cat")]
        public string CategoryName { get; set; }

        [DisplayName("Curr.M")]
        public int CurrentMonth { get; set; }

        [DisplayName("Prev.M")]
        public int PreviousMonth { get; set; }

        [DisplayName("AVG")]
        public int YearAverage { get; set; }

        public int B4PrevMonSummary { get; set; }

        public int B4B4PrevMonSummary { get; set; }
    }
}