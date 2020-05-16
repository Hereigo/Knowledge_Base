namespace EF_UnitOfWork_Repository
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BalanceC")]
    public partial class BalanceC
    {
        public long Id { get; set; }

        public long Country { get; set; }

        public int Year { get; set; }

        public decimal? Exports { get; set; }

        public bool IsAP { get; set; }
    }
}