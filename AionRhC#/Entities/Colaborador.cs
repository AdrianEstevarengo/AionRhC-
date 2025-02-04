namespace AionRhC_.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cargo { get; set; }
        public string Matricula { get; set; }
        public string Setor { get; set; }
        public string Situacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAdmissao { get; set; }
    }
}
