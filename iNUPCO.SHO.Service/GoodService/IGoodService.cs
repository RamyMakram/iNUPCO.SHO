using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.GoodService
{
    public interface IGoodService
    {
        IEnumerable<GoodDTO> GetGoods();
    }
}
