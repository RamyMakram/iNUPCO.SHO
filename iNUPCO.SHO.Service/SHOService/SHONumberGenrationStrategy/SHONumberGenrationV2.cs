using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.SHOService.SHONumberGenrationStrategy
{
    public class SHONumberGenrationV2 : ISHONumberGenrationStrategy
    {
        public int GenrateNumber()
        {
            return (int)DateTime.Now.Ticks + 20;
        }
    }
}
