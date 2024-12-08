using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Service.RabbitMQSrervice
{
    public interface IRabbitMQService
    {
        Task NotifyPOAsync(int SHOID);
    }
}
