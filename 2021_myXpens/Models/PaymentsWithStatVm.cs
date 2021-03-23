using System.Collections.Generic;

namespace MyXpens.Models
{
    public class PaymentsWithStatVm
    {
        public List<Payment> PaymentsVm { get; set; }

        public List<StatistixView> StatistixVm { get; set; }
    }
}