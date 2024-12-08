using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.SHOService.SHONumberGenrationStrategy
{
    public class SHONumberGenrationProcessor(ISHONumberGenrationStrategy shoNumberGenrationStrategy)
    {
        public int ProcessGenrateNumber()
        {
            return shoNumberGenrationStrategy.GenrateNumber();
        }
    }
}
