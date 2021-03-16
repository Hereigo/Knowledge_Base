namespace EF_UnitOfWork_Repository
{
    public class BalanceCAP
    {
        public long Id { get; set; }

        public long Country { get; set; }

        public int Year { get; set; }

        public decimal? Exports { get; set; }

        public bool IsAP { get; set; }
    }
}