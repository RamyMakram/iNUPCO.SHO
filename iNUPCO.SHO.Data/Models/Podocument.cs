using System;
using System.Collections.Generic;

namespace iNUPCO.SHO.Data.Models;

public partial class Podocument
{
    public int PoNumber { get; set; }

    public DateTime PoDate { get; set; }

    public decimal PoTotalAmount { get; set; }

    public int PoState { get; set; }

    public bool PoIsHolded { get; set; }

    public virtual ICollection<PodocumentItem> PodocumentItems { get; set; } = new List<PodocumentItem>();

    public virtual ICollection<Sho> Shos { get; set; } = new List<Sho>();
}
