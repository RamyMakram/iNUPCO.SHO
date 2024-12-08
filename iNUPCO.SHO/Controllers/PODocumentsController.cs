using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using iNUPCO.SHO.DTOs.Global;
using iNUPCO.SHO.Service.GoodService;
using iNUPCO.SHO.Service.PODocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace iNUPCO.SHO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PODocumentsController(IPOService poService, IDistributedCache cache) : ControllerBase
    {
        /// <summary>
        /// Return All PODocuments
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get(PagginationDTO pagginationDTO)
        {
            List<PODocumentDTO> podocuments = new();

            string cacheKey = $"POCache[{pagginationDTO.skip}-{pagginationDTO.pageSize}]";
            var cachedValue = await cache.GetStringAsync(cacheKey);

            if (cachedValue == null|| cachedValue == "[]")
            {
                podocuments = poService.GetPOs(pagginationDTO).ToList();
                await cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(podocuments));
            }
            else
                podocuments = JsonConvert.DeserializeObject<List<PODocumentDTO>>(cachedValue);

            return Ok(new ResponseSchema(IsSuccess: true, Data: podocuments, StatusCode: 200));
        }
    }
}
