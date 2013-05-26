using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
//using Moq;
using RodeoDrive.Domain.Abstract;
using RodeoDrive.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using RodeoDrive.Domain.Concrete;
using System.Configuration;
using RodeoDrive.WebUI.Infrastructure.Abstract;
using RodeoDrive.WebUI.Infrastructure.Concrete;

namespace RodeoDrive.WebUI.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}