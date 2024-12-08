using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;

namespace iNUPCO.SHO.Service.SHOService
{
    public interface ISHOService
    {
        IEnumerable<SHODTO> GetSHOs(PagginationDTO pagginationDTO);
        SHODTO GetSHO(long id);
        Task InsertSHOAsync(SHODTO shoDTO);
    }
}
