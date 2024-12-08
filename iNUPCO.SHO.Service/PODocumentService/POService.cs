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

        public void InsertPO(PODocumentDTO _PODTO)
        {
            //PO.PoTotalAmount = PO.PodocumentItems;
            var PO = _PODTO.Adapt<Podocument>();

            if (PO == null)
                throw new ArgumentNullException("PO Is Null");

            if (PO.PodocumentItems.Count == 0)
                throw new ArgumentNullException("PO Items Is Null");
            if (PO.PodocumentItems.GroupBy(q => q.GoodCode).Any(q => q.Count() > 1))
                throw new InvalidOperationException("Good Cannot Duplicated");

            PO.PoDate = DateTime.Now;

            PO.PoNumber = new PONumberGenrationStrategy.PONumberGenrationProcessor(
                                    new PONumberGenrationStrategy.PONumberGenrationV1()
                                )
                                .ProcessGenrateNumber();

            poRepository.Insert(PO);
            poRepository.SaveChanges();
        }
    }
}
