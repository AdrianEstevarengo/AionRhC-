using AionRhC_.Data.Context;
using AionRhC_.Data.Repositories.Interfaces;
using AionRhC_.Entities;
using Microsoft.EntityFrameworkCore;

namespace AionRhC_.Data.Repositories
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ColaboradorRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public async Task<Colaborador> GetAllColaboradorComAdvertenciasAsync(Guid id)
        {
            return await _dbContext.Colaboradores
                .Include(c => c.Advertencias)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
