using Newtonsoft.Json;

namespace BMH.Domain.DTO
{
    public class CustomerRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Income { get; set; }

        public CustomerRequestDTO()
        {
        }
    }
}
