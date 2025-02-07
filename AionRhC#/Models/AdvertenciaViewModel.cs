using AionRhC_.Entities;

namespace AionRhC_.Models
{
    public class AdvertenciaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; }
        public Guid ColaboradorId { get; set; }
        public Colaborador ? Colaborador { get; set; }
    }
}
