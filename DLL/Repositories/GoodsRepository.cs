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
  
        public class GoodsRepository : IRepository<Goods>
        {
            private StorageContext db;

            public GoodsRepository(StorageContext context)
            {
                this.db = context;
            }

            public IEnumerable<Goods> GetAll()
            {
                return db.Goodss;
            }

            public Goods Get(int id)
            {
                return db.Goodss.Find(id);
            }

            public void Create(Goods goods)
            {
                db.Goodss.Add(goods);
            }

            public void Update(Goods goods)
            {
                db.Entry(goods).State = EntityState.Modified;
            }

            public IEnumerable<Goods> Find(Func<Goods, Boolean> predicate)
            {
                return db.Goodss.Where(predicate).ToList();
            }

            public void Delete(int id)
            {
                Goods goods = db.Goodss.Find(id);
                if (goods != null)
                    db.Goodss.Remove(goods);
            }
        }
  
}
