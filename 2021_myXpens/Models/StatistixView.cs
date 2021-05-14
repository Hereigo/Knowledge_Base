using System.ComponentModel;

namespace MyXpens.Models
{
    public class StatistixView
    {
        [DisplayName("Cat")]
        public string CategoryName { get; set; }

        [DisplayName("Curr.M")]
        public string CurrentMonth { get; set; }

        [DisplayName("Prev.M")]
        public string PreviousMonth { get; set; }

        [DisplayName("AVG")]
        public string YearAverage { get; set; }

        public string B4PrevMonSummary { get; set; }

        public string B4B4PrevMonSummary { get; set; }
    }
}