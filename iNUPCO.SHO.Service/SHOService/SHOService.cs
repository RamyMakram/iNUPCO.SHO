using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;
using iNUPCO.SHO.Repo;
using iNUPCO.SHO.Service.RabbitMQSrervice;
using iNUPCO.SHO.Service.SHOService.SHONumberGenrationStrategy;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.SHOService
{
    public class SHOService
        (
            IRepository<Sho> shoRepository,
            IRepository<Podocument> poRepository,
            IRabbitMQService rabbitMQService

        )
        : ISHOService
    {
        public IEnumerable<SHODTO> GetSHOs(PagginationDTO pagginationDTO)
        {
            return shoRepository.GetAll_Pagging(q => true, pagginationDTO, out int _, new string[] { "PodocumentNumberNavigation.PodocumentItems.GoodCodeNavigation" }).Adapt<List<SHODTO>>();
        }

        public SHODTO GetSHO(long shoNumber)
        {
            return shoRepository.Get(q => q.ShoNumber == shoNumber, new string[] { "PodocumentNumberNavigation.PodocumentItems.GoodCodeNavigation" }).Adapt<SHODTO>();
        }

        public async Task InsertSHOAsync(SHODTO shoDTO)
        {
            //var SHO = shoDTO.Adapt<Sho>();

            //if (SHO == null)
            //    throw new ArgumentNullException("SHO Is Null");

            //var PO_Navigation = poRepository.Get(q => q.PoNumber == SHO.PodocumentNumber, new string[] { "Shos" });

            //if (PO_Navigation == null)
            //    throw new ArgumentNullException("PO Not Exist");
            //if (PO_Navigation.Shos.Any())
            //    throw new InvalidOperationException("PO Is Already Fillfulled");
            //SHO.ShoNumber = new Service.SHOService.SHONumberGenrationStrategy.SHONumberGenrationProcessor(
            //                        new Service.SHOService.SHONumberGenrationStrategy.SHONumberGenrationV1()
            //                    )
            //                    .ProcessGenrateNumber();

            //shoRepository.Insert(SHO);
            //shoRepository.SaveChanges();
            //await rabbitMQService.NotifyPOAsync(SHO.ShoNumber);
            await rabbitMQService.NotifyPOAsync(12);
        }
    }
}
