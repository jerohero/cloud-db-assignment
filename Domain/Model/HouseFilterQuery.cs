
namespace VRefSolutions.Domain.Models
{
    public class HouseFilterQuery
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public HouseFilterQuery() { }
    }
}