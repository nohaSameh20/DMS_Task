using Application.Data;
using Application.Interfaces;
using DMS.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;

namespace VHR.Controllers
{
    public class AccountController : Controller
    {
        public IAccountService accountService;
        public string Base64;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        // GET: AccountController
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {

                var res = accountService.Login(model);
                HttpContext.Session.SetString("UserName", res.Name);
                HttpContext.Session.SetString("UserRole", res.UserRole.ToString());
                if (HttpContext.Session.GetString("UserRole") == "Admin")
                {
                    return RedirectToAction("Index", "Item");
                }

                if (HttpContext.Session.GetString("UserRole") == "Customer")
                {
                    return RedirectToAction("CustomerIndex", "Item");
                }
                return Redirect("/Account/Login");
            }
            catch (Exception ex)
            {

                ErrorrHandling errorHandling = new ErrorrHandling();
                var res = errorHandling.GetErrorMessage(ex);
                TempData["ErrorMessage"] = res;
                return Redirect("/Account/Login");
            }
        }

        public IActionResult Logout() 
        {
            HttpContext.Session.Remove("UserName");
            return Redirect("/Account/Login");
        }
    }
}