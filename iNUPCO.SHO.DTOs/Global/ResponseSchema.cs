using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.DTOs.Global
{
    public record ResponseSchema(bool IsSuccess, int StatusCode, object Data = null, string? ErrorMessage = null);
}
