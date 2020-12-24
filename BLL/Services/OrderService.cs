using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using BLL.Infrastructure;
using BLL.Interfaces;
using AutoMapper;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Goods goods = Database.Goodss.Get(orderDto.GoodsId);

            
            if (goods == null)
                throw new ValidationException("Product not found", "");
            
            Order order = new Order
            {
                Date = DateTime.Now,
                GoodsId = goods.Id,
                Form = orderDto.Form
            };
            Database.Orders.Create(order);
            Database.Goodss.Get(orderDto.GoodsId).Count--;
            Database.Save();
        }

        public IEnumerable<GoodsDTO> GetGoods()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsDTO>>(Database.Goodss.GetAll());
        }

        public GoodsDTO GetGood (int? id)
        {
            if (id == null)
                throw new ValidationException("Product id not set", "");
            var goods = Database.Goodss.Get(id.Value);
            if (goods == null)
                throw new ValidationException("Product not found", "");

            return new GoodsDTO { Id = goods.Id, Name = goods.Name, Price = goods.Price, Count=goods.Count, Date=goods.Date };
        }

        public IEnumerable<OrderDTO> GetOrders()
        { 
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Product id not set", "");
            var order = Database.Orders.Get(id.Value);
            if (order == null)
                throw new ValidationException("Product not found", "");

            return new OrderDTO {Id = order.Id, Form = order.Form, Date = order.Date};
        }

        public void EditOrder(OrderDTO orderDTO)
        {
            var order = Database.Orders.Get(orderDTO.Id);
            Database.Orders.Get(orderDTO.Id).Form= true; 
            Database.Save();
        }

        public IEnumerable<GoodsDTO> GetGoodsByCount(int ? count)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsDTO>>(Database.Goodss.Find(p => p.Count == count));
        }

        public IEnumerable<GoodsDTO> GetGoodsByName(string name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsDTO>>(Database.Goodss.Find(p => p.Name == name));
        }

        public IEnumerable<GoodsDTO> GetGoodsByPrice(int ? price)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsDTO>>(Database.Goodss.Find(p => p.Price == price));
        }

        public IEnumerable<GoodsDTO> GetGoodsByDate(string date)
        {
            DateTime dt = DateTime.Parse(date); 
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods, GoodsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsDTO>>(Database.Goodss.Find(p => p.Date.Date == dt));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
