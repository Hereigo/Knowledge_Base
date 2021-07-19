using Microsoft.EntityFrameworkCore;

namespace EF_Repository_UoW
{
    public class OrderContext : DbContext
    {
        public DbSet<BookAndroid> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class BookAndroid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class BookWindows
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int BookId { get; set; }
        public BookAndroid Book { get; set; }
    }
}
