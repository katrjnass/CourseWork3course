using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class GoodsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
