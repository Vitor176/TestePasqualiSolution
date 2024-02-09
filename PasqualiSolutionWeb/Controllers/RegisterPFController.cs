using PasqualiSolution.Web.Models;
using PasqualiSolution.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace PasqualiSolution.Web.Controllers
{
    public class RegisterPFController : Controller
    {
        private readonly IRegisterPFService _registerPFSerivce;

        public RegisterPFController(IRegisterPFService registerPFService)
        {
            _registerPFSerivce = registerPFService ?? throw new ArgumentNullException(nameof(registerPFService));
        }

        public async Task<IActionResult> RegisterPFIndex()
        {
            var registers = await _registerPFSerivce.FindAllProducts();
            return View(registers);
        }

        public async Task<IActionResult> RegisterCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCreate(RegisterPFModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _registerPFSerivce.CreateProduct(model);
                if (response != null) return RedirectToAction(
                     nameof(RegisterPFIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> RegisterUpdate(int id)
        {
            var model = await _registerPFSerivce.FindProductById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUpdate(RegisterPFModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _registerPFSerivce.UpdateProduct(model);
                if (response != null) return RedirectToAction(
                     nameof(RegisterPFIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> RegisterDelete(int id)
        {
            var model = await _registerPFSerivce.FindProductById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDelete(RegisterPFModel model)
        {
            var response = await _registerPFSerivce.DeleteProductById(model.Id);
            if (response) return RedirectToAction(
                    nameof(RegisterPFIndex));
            return View(model);
        }
    }
}
