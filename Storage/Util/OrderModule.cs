using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Services;
using BLL.Interfaces;

namespace WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}