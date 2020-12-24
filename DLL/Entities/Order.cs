using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public bool Form { get; set; }
        public Goods Goods { get; set; }

        public DateTime Date { get; set; }
    }
}
