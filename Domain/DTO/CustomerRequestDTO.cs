namespace Domain.DTO
{
    public class CustomerRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Income { get; set; }

        public CustomerRequestDto()
        {
        }
    }
}
