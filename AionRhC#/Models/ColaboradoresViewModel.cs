using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AionRhC_.Models
{
    public class ColaboradoresViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Matricula { get; set; }
        public SetorialEnum Setor { get; set; }
        [Display(Name = "Situação")]
        public SituacaoColaboradorEnum Situacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TelefoneEmergencia { get; set; }
        [Display(Name = "Data de Admissão")]
        public DateTime DataAdmissao { get; set; }
        public bool Status { get; set; } = true;
        public List<AdvertenciaViewModel> Advertencias { get; set; } = new List<AdvertenciaViewModel>();
    }
}
