using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;
using iNUPCO.SHO.Service.SHOService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iNUPCO.SHO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SHOsController(ISHOService poService) : ControllerBase
    {
        /// <summary>
        /// Return All PODocuments
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get(PagginationDTO pagginationDTO)
        {
            var podocuments = poService.GetSHOs(pagginationDTO);
            return Ok(new ResponseSchema(IsSuccess: true, Data: podocuments, StatusCode: 200));
        }

        /// <summary>
        /// Return All PODocuments
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSHO(SHODTO sho)
        {
            await poService.InsertSHOAsync(sho);
            return Ok(new ResponseSchema(IsSuccess: true, StatusCode: 200));
        }
    }
}
