using Domain.Entity;
using Domain.Model;

namespace Service.Interface
{
    public interface IHouseService
    {
        public IEnumerable<House> GetHousesInPriceRange(HouseFilterQuery filter);
        public List<string> GetHouseImages(House house);
    }
}