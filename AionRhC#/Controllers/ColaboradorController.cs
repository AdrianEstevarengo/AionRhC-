using AionRhC_.Data.Context;
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
        private readonly IColaboradorRepository _repository;
        private readonly ApplicationDbContext _context;

        public ColaboradorController(IColaboradorRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var colaboradores = await _repository.GetAllAsync();
            var viewModel = ColaboradorFactory.ToViewModelList(colaboradores);
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var colaborador = await _repository.GetByIdAsync(id);
            if (colaborador == null) return NotFound();
            return View(colaborador);
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
                await _context.AddAsync(colaborador);
                return RedirectToAction(nameof(Index));
            }
            return View(colaborador);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var colaborador = await _repository.GetByIdAsync(id);
            if (colaborador == null) return NotFound();
            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Colaborador colaborador)
        {
            if (id != colaborador.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(colaborador);
                return RedirectToAction(nameof(Index));
            }
            return View(colaborador);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var colaborador = await _repository.GetByIdAsync(id);
            if (colaborador == null) return NotFound();
            return View(colaborador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
