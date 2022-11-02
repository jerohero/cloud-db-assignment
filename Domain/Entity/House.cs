using BMH.Repository.Interface;

namespace BMH.Domain
{
    public class House : IBaseEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
    }
}
