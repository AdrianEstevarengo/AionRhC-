using AionRhC_.Data.Context;
using AionRhC_.Data.Repositories.Interfaces;
using AionRhC_.Entities;

namespace AionRhC_.Data.Repositories
{  
    public class AdvertenciasRepository : Repository<Advertencias>, IAdvertenciasRepository
    {
        public AdvertenciasRepository(ApplicationDbContext context) : base(context) { }
    }
}
