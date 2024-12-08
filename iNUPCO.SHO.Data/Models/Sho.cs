using System;
using System.Collections.Generic;

namespace iNUPCO.SHO.Data.Models;

public partial class Sho
{
    public int ShoNumber { get; set; }

    public DateTime DeliveryDate { get; set; }

    public int PalletCount { get; set; }

    public int PodocumentNumber { get; set; }

    public virtual Podocument PodocumentNumberNavigation { get; set; } = null!;
}
