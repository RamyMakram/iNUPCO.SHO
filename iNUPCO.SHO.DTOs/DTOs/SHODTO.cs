using iNUPCO.SHO.DTOs.DTOs;
using System;
using System.Collections.Generic;

namespace iNUPCO.SHO.Data.Models;

public record SHODTO(int ShoNumber, DateTime DeliveryDate, int PalletCount, int PodocumentNumber, PODocumentDTO? PodocumentNumberNavigation = null);

