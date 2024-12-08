using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;

namespace iNUPCO.SHO.Service.PODocumentService
{
    public interface IPOService
    {
        IEnumerable<PODocumentDTO> GetPOs(PagginationDTO pagginationDTO);
        PODocumentDTO GetPO(long id);
        void InsertPO(PODocumentDTO PO);
    }
}
