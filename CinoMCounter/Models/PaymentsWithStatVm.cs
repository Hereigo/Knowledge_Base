using System.Collections.Generic;

namespace CinoMCounter.Models
{
    public class PaymentsWithStatVm
    {
        public List<Payment> PaymentsVm { get; set; }

        public List<StatistixView> StatistixVm { get; set; }
    }
}