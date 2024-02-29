using MagicVilla.Models.Dto;

namespace MagicVilla.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>()
        {
                new VillaDto() {Id = 1, Name ="Beach View", Sqft = 100, Occupancy = 3},
                new VillaDto() {Id = 2,Name = "Pool View", Sqft = 150, Occupancy = 4}
        };
    }
}
