using AutoMapper;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Service.Interface;

namespace Controller
{
    public class MortgageController
    {
        private readonly ILogger _logger;
        private ICustomerService CustomerService { get; }
        private IMortgageService MortgageService { get; }
        private IMapper Mapper { get; }

        public MortgageController(ILoggerFactory loggerFactory, ICustomerService customerService, IMortgageService mortgageService, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<HouseController>();
            CustomerService = customerService;
            MortgageService = mortgageService;
            Mapper = mapper;
        }

        [Function(nameof(GenerateMortgageDocuments))]
        public void GenerateMortgageDocuments([TimerTrigger("0 0 * * *")] TimerInfo timer)
        {
            MortgageService.GenerateCustomerMortgageDocuments();
        }

        [Function(nameof(MailMortgageDocuments))]
        public void MailMortgageDocuments([TimerTrigger("0 6 * * *")] TimerInfo timer)
        {
            MortgageService.MailCustomerMortgageDocuments();
        }

        [Function(nameof(MortgageTriggerTest))]
        public void MortgageTriggerTest([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "mortgage")] HttpRequestData req)
        {
            MortgageService.GenerateCustomerMortgageDocuments();
        }

        [Function(nameof(MailTriggerTest))]
        public void MailTriggerTest([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "mail")] HttpRequestData req)
        {
            MortgageService.MailCustomerMortgageDocuments();
        }
    }
}
