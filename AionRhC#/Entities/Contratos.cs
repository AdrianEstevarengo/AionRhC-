using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Domain.Enums;

namespace Domain.Entities
{
    public class Contratos
    {
        public Guid Id { get; set; }
        public string NumeroProcesso { get; set; } = String.Empty;

        public string Responsavel { get; set; }

        public string Fiscal { get; set; }

        public string Empresa { get; set; } = String.Empty;

        public SituacaoContratoEnum Situacao { get; set; }

        public string? Observacoes { get; set; }

        public DateTime? RecebimentoNf { get; set; }

        public DateTime? PrazoComissao { get; set; }

        public DateTime RecebimentoDefinitivo { get; set; }

        public DateTime? PrazoParaLiquidacao { get; set; }

        public DateTime? PrazoPagamento { get; set; }

        public DateTime? Liquidacao { get; set; }

        public DateTime? PagamentoSigef { get; set; }
        public decimal Valor { get; set; }

        public bool Ativo { get; set; } = true;
    }
}