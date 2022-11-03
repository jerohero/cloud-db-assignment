using Domain.Entity;
using Domain.Model;

namespace Service.Interface
{
    public interface IMortgageService
    {
        public void GenerateUserMortgageDocuments();
        public int CalculateMortgage(int income);
    }
}