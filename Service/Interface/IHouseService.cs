using BMH.Domain;
using BMH.Domain.Models;

namespace BMH.Service
{
    public interface IHouseService
    {
        public List<House> GetHousesInPriceRange(HouseFilterQuery filter);
        public List<string> GetHouseImages(House house);
    }
}