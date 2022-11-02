using BMH.Repository.Interface;

namespace BMH.Domain
{
    public class Customer : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Income { get; set; }
    }
}
