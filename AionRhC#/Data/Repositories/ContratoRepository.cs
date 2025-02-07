using AionRhC_.Data.Context;
using AionRhC_.Data.Repositories;
using Domain.Entities;
using Infra.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ContratoRepository : Repository<Contratos>, IContratoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ContratoRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Contratos>> BuscarContratosPorTermo(string termoDeBusca)
        {
            IQueryable<Contratos> query = _dbContext.Contratos
                .Include(c => c.Responsavel)
                .Include(c => c.Fiscal);

            if (!string.IsNullOrEmpty(termoDeBusca))
            {
                query = query.Where(c =>
                    c.NumeroProcesso.Contains(termoDeBusca) ||
                     c.Empresa.Contains(termoDeBusca)
                );
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Contratos>> GetAllContratosAsync()
        {
            return await _dbContext.Contratos
                .Include(c => c.Responsavel)  // Carrega o funcionário responsável pelo pagamento
                .Include(c => c.Fiscal)       // Carrega o funcionário fiscal do contrato
                .ToListAsync();
        }

    }
}