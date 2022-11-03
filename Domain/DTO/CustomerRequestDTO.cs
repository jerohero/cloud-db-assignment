namespace Domain.DTO
{
    public class CustomerRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Income { get; set; }

        public CustomerRequestDto()
        {
        }
    }
}
