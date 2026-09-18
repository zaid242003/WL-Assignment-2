using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RecruitmentCoreMVC.Models;

namespace RecruitmentCoreMVC.Controllers
{
    public class RecruitmentController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public RecruitmentController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Candidate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string cvFileName = "No file uploaded";
            if (model.CVFile != null && model.CVFile.Length > 0)
            {
                string uploadPath = Path.Combine(_env.WebRootPath, "Uploads");
                Directory.CreateDirectory(uploadPath);

                cvFileName = Path.GetFileName(model.CVFile.FileName);
                string filePath = Path.Combine(uploadPath, cvFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.CVFile.CopyToAsync(stream);
                }
            }

            ViewBag.Message = $"Thank you {model.FullName}, your application has been submitted successfully! CV received: {cvFileName}";
            return View("Success", model);
        }
    }
}
