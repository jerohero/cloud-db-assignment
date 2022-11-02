using Domain.Interface;

namespace Domain.Entity
{
    public class Customer : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Income { get; set; }
    }
}
