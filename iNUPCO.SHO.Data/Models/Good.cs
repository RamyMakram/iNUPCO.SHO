using System;
using System.Collections.Generic;

namespace iNUPCO.SHO.Data.Models;

public partial class Good
{
    public int GoodCode { get; set; }

    public string? GoodName { get; set; }

    public virtual ICollection<PodocumentItem> PodocumentItems { get; set; } = new List<PodocumentItem>();
}
