using System.Collections.Generic;

namespace Payments_Net462.Models
{
    public class PaymentsWithStatVm
    {
        public List<Payment> PaymentsVm { get; set; }

        public StatistixView StatistixVm { get; set; }
    }
}