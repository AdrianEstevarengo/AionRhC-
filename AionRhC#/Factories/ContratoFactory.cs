using AionRhC_.Models;
using Domain.Entities;

namespace Aion.Factories
{
    public static class ContratosFactory
    {
        public static ContratosViewModel EntityParaContratosViewModel(Contratos contrato)
        {
            return new ContratosViewModel
            {
                Id = contrato.Id,
                NumeroProcesso = contrato.NumeroProcesso,
                Responsavel = contrato.Responsavel,
                Fiscal = contrato.Fiscal,
                Empresa = contrato.Empresa,
                Valor = contrato.Valor,
                RecebimentoNf = contrato.RecebimentoNf,
                PrazoComissao = contrato.PrazoComissao,
                RecebimentoDefinitivo = contrato.RecebimentoDefinitivo,
                PrazoParaLiquidacao = contrato.PrazoParaLiquidacao,
                PrazoPagamento = contrato.PrazoPagamento,
                Liquidacao = contrato.Liquidacao,
                PagamentoSigef = contrato.PagamentoSigef,
                Situacao = contrato.Situacao,
                Observacoes = contrato.Observacoes,
                Ativo = contrato.Ativo
            };
        }

        public static Contratos ContratosViewModelParaEntity(ContratosViewModel viewModel)
        {
            return new Contratos
            {
                Id = viewModel.Id,
                NumeroProcesso = viewModel.NumeroProcesso,
                Responsavel = viewModel.Responsavel,
                Fiscal = viewModel.Fiscal,
                Empresa = viewModel.Empresa,
                Valor = viewModel.Valor,
                RecebimentoNf = viewModel.RecebimentoNf,
                PrazoComissao = viewModel.PrazoComissao,
                RecebimentoDefinitivo = viewModel.RecebimentoDefinitivo,
                PrazoParaLiquidacao = viewModel.PrazoParaLiquidacao,
                PrazoPagamento = viewModel.PrazoPagamento,
                Liquidacao = viewModel.Liquidacao,
                PagamentoSigef = viewModel.PagamentoSigef,
                Situacao = viewModel.Situacao,
                Observacoes = viewModel.Observacoes,
                Ativo = viewModel.Ativo
            };
        }

        public static List<ContratosViewModel> ListEntityParaListContratosViewModel(IEnumerable<Contratos> entities)
        {
            return entities.Select(EntityParaContratosViewModel).ToList();
        }

        public static List<Contratos> ListContratosViewModelParaListEntity(IEnumerable<ContratosViewModel> viewModels)
        {
            return viewModels.Select(ContratosViewModelParaEntity).ToList();
        }
    }
}