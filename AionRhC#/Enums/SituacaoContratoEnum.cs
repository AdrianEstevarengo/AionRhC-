using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum SituacaoContratoEnum
    {
        [Display(Name = "Pagamento")]
        Pagamento,
        [Display(Name = "Liquidação")]
        Liquidacao,
        [Display(Name = "Concluído")]
        Concluido,
        [Display(Name = "Pendência")]
        Pendencia

    }
}