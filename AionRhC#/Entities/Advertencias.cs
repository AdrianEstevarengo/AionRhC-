namespace AionRhC_.Entities
{
    public class Advertencias
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public string Observacao { get; set; }
        public Guid ColaboradorId { get; set; }
        public virtual Colaborador Colaborador { get; set; }
    }
}
