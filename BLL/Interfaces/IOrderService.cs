using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        GoodsDTO GetGood (int? id);
        IEnumerable<GoodsDTO> GetGoods();
        IEnumerable<GoodsDTO> GetGoodsByPrice(int ? price);
        IEnumerable<GoodsDTO> GetGoodsByName(string name);
        IEnumerable<GoodsDTO> GetGoodsByCount(int ? count);
        IEnumerable<GoodsDTO> GetGoodsByDate(string date);

        void EditOrder(OrderDTO orderDto);
        OrderDTO GetOrder(int? id);
        IEnumerable<OrderDTO> GetOrders();
        void Dispose();
    }
}
