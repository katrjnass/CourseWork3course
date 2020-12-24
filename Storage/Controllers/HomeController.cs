using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using WEB.Models;
using AutoMapper;
using BLL.Infrastructure;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index(string date, int ? price, int ? count, string searchString)
        {
            
            if(!String.IsNullOrEmpty(searchString))
            {
                IEnumerable<GoodsDTO> goodsDTOs = orderService.GetGoodsByName(searchString);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodsDTO, GoodsViewModel>()).CreateMapper();
                var goods = mapper.Map<IEnumerable<GoodsDTO>, List<GoodsViewModel>>(goodsDTOs);
                return View(goods);
            }
            else
             if (price != 0)
            {
                IEnumerable<GoodsDTO> goodsDtos = orderService.GetGoodsByPrice(price);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodsDTO, GoodsViewModel>()).CreateMapper();
                var goods = mapper.Map<IEnumerable<GoodsDTO>, List<GoodsViewModel>>(goodsDtos);
                return View(goods);
            }
            else
             if (count != 0)
            {
                IEnumerable<GoodsDTO> goodsDtos = orderService.GetGoodsByCount(count);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodsDTO, GoodsViewModel>()).CreateMapper();
                var goods = mapper.Map<IEnumerable<GoodsDTO>, List<GoodsViewModel>>(goodsDtos);
                return View(goods);
            }
            else
             if (!String.IsNullOrEmpty(date))
            {
                IEnumerable<GoodsDTO> goodsDtos = orderService.GetGoodsByDate(date);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodsDTO, GoodsViewModel>()).CreateMapper();
                var goods = mapper.Map<IEnumerable<GoodsDTO>, List<GoodsViewModel>>(goodsDtos);
                return View(goods);
            }
            else
            {
               IEnumerable<GoodsDTO> goodsDtos = orderService.GetGoods();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodsDTO, GoodsViewModel>()).CreateMapper();
                var goods = mapper.Map<IEnumerable<GoodsDTO>, List<GoodsViewModel>>(goodsDtos);
                return View(goods);
            }
         
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                GoodsDTO goods = orderService.GetGood(id);
                var order = new OrderViewModel { GoodsId = goods.Id};

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO { Id = order.GoodsId, GoodsId= order.Id, Form = order.Form, Date = order.Date, GoodsPrice = order.GoodsPrice, GoodsCount=order.GoodsCount,  GoodsName = order.GoodsName, GoodsDate= order.GoodsDate };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Your order has been generated</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult MyGoods()
        {
            IEnumerable<OrderDTO> orderDtos = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDtos);
            return View(orders);
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {

            OrderDTO order = orderService.GetOrder(id);
            var order2 = new OrderViewModel { Id = order.Id };

            return View(order2);

        }

        [HttpPost]
        public ActionResult EditOrder(OrderDTO order)
        {
            try
            {
                var orderDto = new OrderDTO { Id = order.Id, GoodsId = order.GoodsId, Form = order.Form };
                orderService.EditOrder(orderDto);
                return Content("< h2 >Goods purchased successfully</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult SearchingByPrice()
        {
            return View();
        }

    }
}