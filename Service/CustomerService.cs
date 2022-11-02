using BMH.Repository.Interfaces;

namespace BMH.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _houseRepository { get; }

        public CustomerService(ICustomerRepository customerRepository)
        {
            _houseRepository = customerRepository;
        }
    }
}