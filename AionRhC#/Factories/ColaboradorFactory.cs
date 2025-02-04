using AionRhC_.Entities;
using AionRhC_.Models;

namespace AionRhC_.Factories
{

    public static class ColaboradorFactory
    {
        public static ColaboradoresViewModel ToViewModel(Colaborador colaborador)
        {
            return new ColaboradoresViewModel
            {
                Nome = colaborador.NomeCompleto,
                Cargo = colaborador.Cargo,
                Matricula = colaborador.Matricula,
                Setor = colaborador.Setor,
                Situacao = colaborador.Situacao,
                Email = colaborador.Email,
                Telefone = colaborador.Telefone,
                DataAdmissao = colaborador.DataAdmissao
            };
        }

        public static List<ColaboradoresViewModel> ToViewModelList(IEnumerable<Colaborador> colaboradores)
        {
            return colaboradores.Select(ToViewModel).ToList();
        }
    }
}
