using AionRhC_.Data.Context;
using AionRhC_.Data.Repositories;
using AionRhC_.Data.Repositories.Interfaces;
using AionRhC_.Entities;
using AionRhC_.Factories;
using AionRhC_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AionRhC_.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _ColaboradorRepository;
        private readonly IAdvertenciasRepository _AdvertenciasRepository;
        private readonly ApplicationDbContext _context;

        public ColaboradorController(IColaboradorRepository repository, ApplicationDbContext context, IAdvertenciasRepository advertenciasRepository)
        {
            _ColaboradorRepository = repository;
            _context = context;
            _AdvertenciasRepository = advertenciasRepository;
        }

        public async Task<IActionResult> Index()
        {
            var colaboradores = await _ColaboradorRepository.GetAllAsync();
            var viewModel = ColaboradorFactory.ListColaboradorToViewModelList(colaboradores);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var colaborador = await _ColaboradorRepository.GetByIdAsync(id);
            if (colaborador == null) return NotFound();

            return Json(colaborador);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                await _ColaboradorRepository.InsertAsync(colaborador);
                return RedirectToAction(nameof(Index));
            }
            return View(colaborador);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var colaborador = await _ColaboradorRepository.GetByIdAsync(id);
            if (colaborador == null) return NotFound();
            return View(colaborador);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ColaboradoresViewModel viewModel)
        {
            if (viewModel == null) return BadRequest();

            var colaboradorExistente = await _ColaboradorRepository.GetByIdAsync(viewModel.Id);
            if (colaboradorExistente == null) return NotFound();

            var colaboradorAtualizado = ColaboradorFactory.ColaboradorViewModelToEntity(viewModel, colaboradorExistente);
            await _ColaboradorRepository.UpdateAsync(colaboradorAtualizado);

            return Ok();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var colaborador = await _ColaboradorRepository.GetByIdAsync(id);
            if (colaborador == null) return NotFound();
            return View(colaborador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _ColaboradorRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Método para adicionar uma advertência
        [HttpPost]
        public async Task<IActionResult> AdicionarAdvertencia([FromBody] AdvertenciaViewModel model)
        {
            if (model == null) return BadRequest("Dados inválidos.");

            var colaborador = await _ColaboradorRepository.GetByIdAsync(model.IdColaborador);
            if (colaborador == null) return NotFound();

            var advertencia = new Advertencias
            {
                Id = Guid.NewGuid(),
                Data = model.Data,
                DataDeVencimento = model.DataVencimento,
                Observacao = model.Observacao,
                IdColaborador = model.IdColaborador
            };

            await _AdvertenciasRepository.InsertAsync(advertencia);
            return Ok(new { success = true, message = "Advertência adicionada com sucesso!" });
        }


        // Método para remover uma advertência
        [HttpPost]
        public async Task<IActionResult> RemoverAdvertencia(Guid colaboradorId, Guid advertenciaId)
        {
            var advertencia = await _AdvertenciasRepository.GetByIdAsync(advertenciaId);
            if (advertencia == null) return NotFound();

            await _AdvertenciasRepository.DeleteAsync(advertenciaId);

            return RedirectToAction(nameof(Edit), new { id = colaboradorId });
        }
    }
}
