using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.DTOs.Global
{
    public class PagginationDTO
    {
        public int pageSize { get; set; }
        public int skip { get; set; }
        public string searchValue { get; set; }
        public string searchColumn { get; set; }
        public string sortColumn { get; set; }
        public string sortColumnDirection { get; set; }
    }
}
