﻿using System;
using System.Web.Mvc;
using RodeoDrive.Domain.Entities;

namespace RodeoDrive.WebUI.Binders
{
    public class CartModelBinder :IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            return cart;
        }
    }
}