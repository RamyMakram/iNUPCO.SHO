using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.DTOs.DTOs
{
    public record PODocumentDTO(int Number, DateTime Date, decimal Amount, int State, bool IsHolded, List<GoodDTO> Goods,List<PODocumentItemDTO> POItems);
}
