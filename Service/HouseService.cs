using BMH.Repository.Interfaces;
using BMH.Service.Interfaces;

namespace BMH.Service
{
    public class HouseService : IHouseService
    {
        IHouseRepository HouseRepository { get; }

        public HouseService(IHouseRepository houseRepository)
        {
            HouseRepository = houseRepository;
        }
    }
}