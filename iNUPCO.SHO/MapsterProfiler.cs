using iNUPCO.SHO.Data.Models;
using iNUPCO.SHO.DTOs.DTOs;
using Mapster;

namespace iNUPCO.SHO
{
    public class MapsterProfiler
    {
        public MapsterProfiler()
        {
            TypeAdapterConfig<Good, GoodDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Name, src => src.GoodName)
                .Map(dest => dest.Code, src => src.GoodCode);

            TypeAdapterConfig<PodocumentItem, PODocumentItemDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Good, src => src.GoodCodeNavigation)
                .Map(dest => dest.GoodCode, src => src.GoodCode)
                .Map(dest => dest.PurchasedGoodPrice, src => src.PurchasedGoodPrice)
                .Map(dest => dest.SerialNumber, src => src.SerialNumber);

            TypeAdapterConfig<Podocument, PODocumentDTO>
                .NewConfig()
                .TwoWays()
                .Map(dest => dest.Amount, src => src.PoTotalAmount)
                .Map(dest => dest.Date, src => src.PoDate)
                .Map(dest => dest.IsHolded, src => src.PoIsHolded)
                .Map(dest => dest.Number, src => src.PoNumber)
                .Map(dest => dest.POItems, src => src.PodocumentItems)
                .Map(dest => dest.State, src => src.PoState);

        }

    }
}
