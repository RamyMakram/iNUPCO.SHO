using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.Repo;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.GoodService
{
    public class GoodService
        (
            IRepository<Good> goodRepository
        )
        : IGoodService
    {
        public IEnumerable<GoodDTO> GetGoods()
        {
            return goodRepository.GetAll().Adapt<List<GoodDTO>>();
        }
    }
}
