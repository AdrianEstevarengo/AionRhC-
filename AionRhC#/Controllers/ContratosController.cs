using Aion.Factories;
using Aion.ViewModels;
using Domain.Entities;
using Domain.Enums;
using Infra.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AionRhC_.Controllers
{
    public class ContratosController : Controller
    {
        private readonly IContratoRepository _contratoRepository;

        public ContratosController(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }
        public async Task<IActionResult> Index()
        {
            var contratos = await _contratoRepository.GetAllAsync();
            return View(contratos);
        }

        public IActionResult CriarContrato()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarContrato(Contratos contrato)
        {
            if (ModelState.IsValid)
            {
                contrato.Id = Guid.NewGuid();
                await _contratoRepository.InsertAsync(contrato);
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var contrato = await _contratoRepository.GetByIdAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Contratos contrato)
        {
            if (id != contrato.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _contratoRepository.UpdateAsync(contrato);
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        public async Task<ActionResult> DetailsAsync(Guid Id)
        {
            var contrato = await _contratoRepository.GetByIdAsync(Id);
            if (contrato == null)
            {
                return NotFound();
            }
            var contratosViewModel = ContratosFactory.EntityParaContratosViewModel(contrato);
            return PartialView(viewName: "_DetailsContratoModal", model: contratosViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtivarContrato(Guid id)
        {
            var contrato = await _contratoRepository.GetByIdAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            contrato.Ativo = true;
            await _contratoRepository.UpdateAsync(contrato);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InativarContrato(Guid id)
        {
            var contrato = await _contratoRepository.GetByIdAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            contrato.Ativo = false;
            await _contratoRepository.UpdateAsync(contrato);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BuscarContratos(string termoDeBusca)
        {
            var contratosFiltrados = await _contratoRepository.BuscarContratosPorTermo(termoDeBusca);
            var contratosViewModel = ContratosFactory.ListEntityParaListContratosViewModel(contratosFiltrados);
            return PartialView("Contratos/_ContratosPartialView", contratosViewModel);
        }
    }
}
