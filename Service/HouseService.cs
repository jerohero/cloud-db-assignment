using BMH.Repository.Interfaces;
using BMH.Service.Interfaces;
using Repository;
using VRefSolutions.Domain.Models;

namespace BMH.Service
{
    public class HouseService : IHouseService
    {
        private IHouseRepository _houseRepository { get; }

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public List<House> GetHousesInPriceRange(HouseFilterQuery filter)
        {
            int minPrice = filter?.MinPrice ?? 0;
            int maxPrice = filter?.MaxPrice ?? int.MaxValue;

            return _houseRepository
                .GetAll()
                .Where(o => o.Price >= minPrice && o.Price <= maxPrice)
                .ToList();
        }
    }
}