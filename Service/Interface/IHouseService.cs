using Repository;
using VRefSolutions.Domain.Models;

namespace BMH.Service.Interfaces
{
    public interface IHouseService
    {
        public List<House> GetHousesInPriceRange(HouseFilterQuery filter);
    }
}