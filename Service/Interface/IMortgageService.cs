using Domain.Entity;
using Domain.Model;

namespace Service.Interface
{
    public interface IMortgageService
    {
        public void GenerateCustomerMortgageDocuments();
        public int CalculateMortgage(int income);
        public void MailCustomerMortgageDocuments();
    }
}