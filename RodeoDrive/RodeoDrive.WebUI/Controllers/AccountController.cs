using System.Web.Mvc;
using RodeoDrive.WebUI.Infrastructure.Abstract;
using RodeoDrive.WebUI.Models;

namespace RodeoDrive.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Неправильні ім'я користувача або пароль");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
