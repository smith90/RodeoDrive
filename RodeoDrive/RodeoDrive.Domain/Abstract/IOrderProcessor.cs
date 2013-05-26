using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RodeoDrive.Domain.Entities;

namespace RodeoDrive.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
