using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quoteGeneratorAPI.Models;

namespace quoteGeneratorAPI.Controllers {

    public class QuoteAdminController : Controller {

        private readonly IWebHostEnvironment environment;
        public QuoteAdminController(IWebHostEnvironment env) {
            environment = env;
        }

        // ------------------------------------ Administration Web App
        public IActionResult Index() {
            AdminManager adminManager = new AdminManager();
            return View(adminManager);
        }

        public IActionResult IndexAfterSubmit() {
            AdminManager adminManager = new AdminManager();
            if (TempData["feedbackAdd"] != null) adminManager.feedbackAdd = TempData["feedbackAdd"].ToString();
            else if (TempData["feedbackDel"] != null) adminManager.feedbackDel = TempData["feedbackDel"].ToString();
            return View("Index", adminManager);
        }

        [HttpPost]
        public IActionResult Add_Submit(AdminManager adminManager, IFormFile selectedFile) {
            if (ModelState.IsValid) {
                // got in here then form validation is successful - BUT what about form upload/save to db?
                bool success = adminManager.add(environment, selectedFile);
                if (success) {
                    // implementing PRG pattern here
                    // all is good - redirect to admin (will refresh all data automatically with re-construction)
                    // using TempData for state management of the add and delete feedback - uses cookies by default but can use session
                    TempData["feedbackAdd"] = adminManager.feedbackAdd;
                    return RedirectToAction("IndexAfterSubmit");
                }
            }
            // there was an issue with file upload (or tampering with client side) - display feedback message
            return View("Index", adminManager);
        }

        [HttpPost]
        public IActionResult Delete_Submit(AdminManager adminManager) {
            // delete method needs environment to delete actual image file
            adminManager.delete(environment);
            TempData["feedbackDel"] = adminManager.feedbackDel;
            return RedirectToAction("IndexAfterSubmit");
        }

    }
}