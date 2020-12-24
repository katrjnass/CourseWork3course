using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Entities;
using DAL.EF;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private StorageContext db;

        public OrderRepository(StorageContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Goods);
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
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Goods).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
