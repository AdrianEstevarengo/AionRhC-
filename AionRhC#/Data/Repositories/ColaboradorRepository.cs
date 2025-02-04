using AionRhC_.Data.Context;
using AionRhC_.Data.Repositories.Interfaces;
using AionRhC_.Entities;

namespace AionRhC_.Data.Repositories
{  
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(ApplicationDbContext context) : base(context) { }
    }
}
