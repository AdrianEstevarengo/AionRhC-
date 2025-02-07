using AionRhC_.Entities;

namespace AionRhC_.Data.Repositories.Interfaces
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        Task<Colaborador> GetAllColaboradorComAdvertenciasAsync(Guid id);

    }
}
