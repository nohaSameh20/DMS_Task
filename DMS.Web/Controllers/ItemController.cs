using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DMS.Application.Items;
using DMS.Application.Items.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Web.Controllers
{
    public class ItemController : Controller
    {
        IGetItemsQuery GetItemsQuery;
        IAddItemFactory AddItemFactory;
        IAddItemCommand AddItemCommand;
        public IHostingEnvironment ihostingEnvironment;
        public string Base64;
        [BindProperty]
        public IFormFile ImageUploader { get; set; }
        public string FileName { get; set; }

        public ItemController(IGetItemsQuery GetItemsQuery, IAddItemFactory AddItemFactory,
                              IAddItemCommand AddItemCommand, IHostingEnvironment ihostingEnvironment)
        {
            this.GetItemsQuery = GetItemsQuery;
            this.AddItemCommand = AddItemCommand;
            this.AddItemFactory = AddItemFactory;
            this.ihostingEnvironment = ihostingEnvironment;
        }

        public IActionResult Index()
        {
            try
            {

                var res = GetItemsQuery.Execute();
                foreach (var item in res)
                {
                    if (item.Image != null)
                    {
                        using (Image image = Image.FromFile(item.Image))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();

                                // Convert byte[] to Base64 String
                                Base64 = Convert.ToBase64String(imageBytes);
                                item.Image = Base64;
                            }
                        }
                    }

                }
                return View(res);
            }
            catch (Exception ex)
            {

                ErrorrHandling errorHandling = new ErrorrHandling();
                var res = errorHandling.GetErrorMessage(ex);
                TempData["ErrorMessage"] = res;
                return Redirect("/Item/Index");
            }
        }
        public IActionResult CustomerIndex()
        {
            try
            {

                var res = GetItemsQuery.Execute();
                foreach (var item in res)
                {
                    if (item.Image != null)
                    {
                        using (Image image = Image.FromFile(item.Image))
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                image.Save(m, image.RawFormat);
                                byte[] imageBytes = m.ToArray();

                                // Convert byte[] to Base64 String
                                Base64 = Convert.ToBase64String(imageBytes);
                                item.Image = Base64;
                            }
                        }
                    }

                }
                return View(res);
            }
            catch (Exception ex)
            {

                ErrorrHandling errorHandling = new ErrorrHandling();
                var res = errorHandling.GetErrorMessage(ex);
                TempData["ErrorMessage"] = res;
                return Redirect("/Item/Index");
            }
        }
        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(AddItemModel model)
        {
            try
            {
                TempData["ImageUpload"] = ImageUploader;

                if (ImageUploader != null)
                {
                    var fileUpload = Path.Combine(ihostingEnvironment.ContentRootPath, "Files", ImageUploader.FileName);
                    var stream = new MemoryStream();
                    var img = ImageUploader.CopyToAsync(stream);
                    var fileBytes = stream.ToArray();
                    string base64 = Convert.ToBase64String(fileBytes);
                    model.Image = base64;
                    var res = AddItemCommand.Execute(model);
                }
                TempData["ImageUpload"] = null;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult AddToCart(Guid Id)
        {
            return View();
        }

    }
}
