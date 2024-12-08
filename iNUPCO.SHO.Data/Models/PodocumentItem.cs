using System;
using System.Collections.Generic;

namespace iNUPCO.SHO.Data.Models;

public partial class PodocumentItem
{
    public int Id { get; set; }

    public int PodocumentNumber { get; set; }

    public int GoodCode { get; set; }

    public int SerialNumber { get; set; }

    public decimal PurchasedGoodPrice { get; set; }

    public virtual Good GoodCodeNavigation { get; set; } = null!;

    public virtual Podocument PodocumentNumberNavigation { get; set; } = null!;
}
