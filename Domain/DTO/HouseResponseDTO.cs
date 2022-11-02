using Domain.Entity;
using Newtonsoft.Json;

namespace Domain.DTO
{
    public class HouseResponseDto
    {
        [JsonRequired]
        public int Id { get; set; }

        [JsonRequired]
        public string Address { get; set; }

        [JsonRequired]
        public string City { get; set; }

        [JsonRequired]
        public int Price { get; set; }

        [JsonRequired]
        public List<string> Images { get; set; }

        public HouseResponseDto(House house, List<string> images)
        {
            Id = house.Id;
            Address = house.Address;
            City = house.City;
            Price = house.Price;
            Images = images;
        }
    }
}
