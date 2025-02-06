using AionRhC_.Entities;
using AionRhC_.Models;

namespace AionRhC_.Factories
{

    public static class ColaboradorFactory
    {
        public static ColaboradoresViewModel ColaboradorToViewModel(Colaborador colaborador)
        {
            return new ColaboradoresViewModel
            {
                Id = colaborador.Id,
                Nome = colaborador.NomeCompleto,
                Cargo = colaborador.Cargo,
                Matricula = colaborador.Matricula,
                Setor = colaborador.Setor,
                Situacao = colaborador.Situacao,
                Email = colaborador.Email,
                Telefone = colaborador.Telefone,
                DataAdmissao = colaborador.DataAdmissao,
                Advertencias = colaborador.Advertencias?.Select(a => new AdvertenciaViewModel
                {
                    Data = a.Data,
                    DataVencimento = a.DataDeVencimento,
                    Observacao = a.Observacao
                }).ToList() ?? new List<AdvertenciaViewModel>()
            };
        }

        public static List<ColaboradoresViewModel> ListColaboradorToViewModelList(IEnumerable<Colaborador> colaboradores)
        {
            return colaboradores.Select(ColaboradorToViewModel).ToList();
        }

        public static Colaborador ColaboradorViewModelToEntity(ColaboradoresViewModel viewModel, Colaborador? colaborador = null)
        {
            colaborador ??= new Colaborador();

            colaborador.Id = viewModel.Id;
            colaborador.NomeCompleto = viewModel.Nome;
            colaborador.Cargo = viewModel.Cargo;
            colaborador.Matricula = viewModel.Matricula;
            colaborador.Setor = viewModel.Setor;
            colaborador.Situacao = viewModel.Situacao;
            colaborador.Email = viewModel.Email;
            colaborador.Telefone = viewModel.Telefone;
            colaborador.DataAdmissao = viewModel.DataAdmissao;
            colaborador.Advertencias = viewModel.Advertencias?.Select(a => new Advertencias
            {
                Id = Guid.NewGuid(), // Se for um novo, gera um novo Id
                Data = a.Data,
                DataDeVencimento = a.DataVencimento,
                Observacao = a.Observacao,
                IdColaborador = colaborador.Id
            }).ToList() ?? new List<Advertencias>();

            return colaborador;
        }
    }
}

