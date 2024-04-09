using Microsoft.AspNetCore.Mvc;
using MvcClienteApiCrudDepartamentos.Models;
using MvcClienteApiCrudDepartamentos.Services;

namespace MvcClienteApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private ServiceApiDepartamentos service;
        public DepartamentosController(ServiceApiDepartamentos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.service.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.service.FindDepartamentoAsync(id);
            return View(dept);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteDepartamentoAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Cliente()
        {
            return View();
        }
    }
}
