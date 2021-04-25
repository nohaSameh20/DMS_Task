using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Shared;
using Application.Users;
using DMS.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class UserController : Controller
    {
        public IAddUserCommand addUserCommand;
        public UserController( IAddUserCommand addUserCommand)
        {
            this.addUserCommand = addUserCommand;
            
        }

        public IActionResult Index()
        {
            return Redirect("/Account/Login");

        }

        public ActionResult Add()
        {
            try
            {
                return View("Add");
            }
            catch (Exception ex)
            {

                ErrorrHandling errorHandling = new ErrorrHandling();
                var res = errorHandling.GetErrorMessage(ex);
                TempData["ErrorMessage"] = res;
                return Redirect("/User/Add");
            }
        }

        [HttpPost]
        public IActionResult Add(AddUserModel model)
        {
            try
            {

                var res = addUserCommand.Execute(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ErrorrHandling errorHandling = new ErrorrHandling();
                var res = errorHandling.GetErrorMessage(ex);
                TempData["ErrorMessage"] = res;
                return Redirect("/User/Add");
            }
        }


    }
}
