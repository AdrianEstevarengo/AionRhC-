using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AionRhC_.Entities
{
    public class Colaborador
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cargo { get; set; }
        public string Matricula { get; set; }
        public SetorialEnum Setor { get; set; }
        [Display(Name = "Situação")]
        public SituacaoColaboradorEnum Situacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Telefone de Emergência")]
        public string TelefoneEmergencia { get; set; }
        [Display(Name = "Data de Admissão")]
        public DateTime DataAdmissao { get; set; }
        public bool Status { get; set; } = true;
        public List<Advertencias> ? Advertencias  { get; set; } = new List<Advertencias>();
    }
}