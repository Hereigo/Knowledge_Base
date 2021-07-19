using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Repository_UoW
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly OrderContext db;

        public OrdersRepository(OrderContext context)
        {
            db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Book);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
    }
}