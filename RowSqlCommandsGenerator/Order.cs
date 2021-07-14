using System.ComponentModel.DataAnnotations.Schema;

namespace RawSqlCommandsGenerator
{
    public class Order
    {
        [Column("ID")]
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Column("Description")]
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
    }
}