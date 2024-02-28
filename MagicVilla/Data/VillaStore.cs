using MagicVilla.Models.Dto;

namespace MagicVilla.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>()
        {
                new VillaDto() {Id = 1, Name ="Beach View"},
                new VillaDto() {Id = 2,Name = "Pool View"}
        };
    }
}
