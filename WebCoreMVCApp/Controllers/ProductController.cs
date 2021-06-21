using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreMVCApp.Controllers
{
    public class ProductController:Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {


            return Json(_webHostEnvironment.WebRootPath);
        }

        public string uploadProductImage()
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString()+Path.GetExtension(files[0].FileName);

            using (var fileStream= new FileStream(Path.Combine(webRootPath, fileName), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
