using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StorageContext db;
        private GoodsRepository goodsRepository;
        private OrderRepository orderRepository;


        public EFUnitOfWork(string connectionString)
        {
            db = new StorageContext(connectionString);
        }
        public IRepository<Goods> Goodss
        {
            get
            {
                if (goodsRepository == null)
                    goodsRepository = new GoodsRepository(db);
                return goodsRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
