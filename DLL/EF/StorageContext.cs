using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.EF
{
    public class StorageContext:DbContext
    {
        public DbSet<Goods> Goodss { get; set; }
        public DbSet<Order> Orders { get; set; }

        static StorageContext()
        {
            Database.SetInitializer<StorageContext>(new StoreDbInitializer());
        }
        public StorageContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StorageContext>
    {
        protected override void Seed(StorageContext db)
        {
           
            
            db.Goodss.Add(new Goods {Name = "Cobi конструктор", Price = 223, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Goodss.Add(new Goods { Name = "машинка ВАЗ ", Price = 279, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Goodss.Add(new Goods { Name = "Lego", Price = 900, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Goodss.Add(new Goods { Name = "Mehano", Price = 1023, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Goodss.Add(new Goods { Name = "Orange пудель", Price = 223, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Goodss.Add(new Goods { Name = "Hola Toys", Price = 850, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });
            db.Goodss.Add(new Goods { Name = "Djeco гра", Price = 300, Count = 50, Date = new DateTime(2020, 2, 18, 17, 0, 0) });

            db.SaveChanges();

        }
    }
}
