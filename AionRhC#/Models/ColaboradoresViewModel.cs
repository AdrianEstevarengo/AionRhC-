using System.ComponentModel.DataAnnotations;

namespace AionRhC_.Models
{
    public class ColaboradoresViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Matricula { get; set; }
        public string Setor { get; set; }
        [Display(Name = "Situação")]
        public string Situacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Data de Admissão")]
        public DateTime DataAdmissao { get; set; }
        public List<AdvertenciaViewModel> Advertencias { get; set; } = new List<AdvertenciaViewModel>();
    }
}
