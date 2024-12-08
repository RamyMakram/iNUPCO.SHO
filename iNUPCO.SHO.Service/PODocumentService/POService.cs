using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;
using iNUPCO.SHO.Repo;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.PODocumentService
{
    public class POService
        (
            IRepository<Podocument> poRepository

        )
        : IPOService
    {
        public IEnumerable<PODocumentDTO> GetPOs(PagginationDTO pagginationDTO)
        {
            return poRepository.GetAll_Pagging(q => true, pagginationDTO, out int _, new string[] { "PodocumentItems.GoodCodeNavigation" }).Adapt<List<PODocumentDTO>>();
        }

        public PODocumentDTO GetPO(long PoNumber)
        {
            return poRepository.Get(q => q.PoNumber == PoNumber, new string[] { "PodocumentItems.GoodCodeNavigation" }).Adapt<PODocumentDTO>();
        }
    }
}
