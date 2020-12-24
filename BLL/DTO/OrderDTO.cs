using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public bool Form { get; set; }
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int GoodsCount { get; set; }
        public int GoodsPrice { get; set; }
        public DateTime GoodsDate { get; set; }
        public DateTime Date { get; set; }
    }
}
