using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public  int Price { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
