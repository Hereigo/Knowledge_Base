using System.Collections.Generic;

namespace MyXpens.Models
{
    public class PaymentsWithStatVm
    {
        public List<PaymentVM> PaymentsVm { get; set; }

        public List<StatistixView> StatistixVm { get; set; }
    }
}