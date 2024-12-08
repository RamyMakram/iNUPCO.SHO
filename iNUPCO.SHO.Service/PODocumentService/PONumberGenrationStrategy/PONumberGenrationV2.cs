﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.PODocumentService.PONumberGenrationStrategy
{
    public class PONumberGenrationV2 : IPONumberGenrationStrategy
    {
        public int GenrateNumber()
        {
            return (int)DateTime.Now.Ticks+20;
        }
    }
}