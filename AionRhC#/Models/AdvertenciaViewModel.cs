using AionRhC_.Entities;

namespace AionRhC_.Models
{
    public class AdvertenciaViewModel
    {
        public DateTime Data { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; }
        public Guid IdColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
