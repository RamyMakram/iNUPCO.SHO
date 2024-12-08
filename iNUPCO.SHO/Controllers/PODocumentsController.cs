using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;
using iNUPCO.SHO.Service.GoodService;
using iNUPCO.SHO.Service.PODocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iNUPCO.SHO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PODocumentsController(IPOService poService) : ControllerBase
    {
        /// <summary>
        /// Return All PODocuments
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get(PagginationDTO pagginationDTO)
        {
            var podocuments = poService.GetPOs(pagginationDTO);
            return Ok(new ResponseSchema(IsSuccess: true, Data: podocuments, StatusCode: 200));
        }
    }
}
