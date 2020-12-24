using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Goods> Goodss { get; }
        IRepository<Order> Orders { get;  }
        void Save();
    }
}
