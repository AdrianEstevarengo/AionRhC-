using AionRhC_.Data.Repositories.Interfaces;
using Domain.Entities;

namespace Infra.Data.Repositories.Interfaces
{
    public interface IContratoRepository : IRepository<Contratos>
    {
        Task<IEnumerable<Contratos>> BuscarContratosPorTermo(string termoDeBusca);
        Task<IEnumerable<Contratos>> GetAllContratosAsync();
    }
}