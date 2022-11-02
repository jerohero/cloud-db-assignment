using System.Net;
using BMH.Domain.DTO;
using BMH.Domain.Models;
using BMH.Service;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using BMH.Domain;
using Newtonsoft.Json;
using BMH.Validators;

namespace BMH.Controller
{
    public class CustomerController
    {
        private readonly ILogger _logger;
        private ICustomerService _customerService { get; }

        public CustomerController(ILoggerFactory loggerFactory, ICustomerService customerService)
        {
            _logger = loggerFactory.CreateLogger<HouseController>();
            _customerService = customerService;
        }

        [Function(nameof(CustomerController.CreateCustomer))]
        public async Task<HttpResponseData> CreateCustomer([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "customer")] HttpRequestData req)
        {
            CustomerRequestDTO dto = JsonConvert.DeserializeObject<CustomerRequestDTO>(await new StreamReader(req.Body).ReadToEndAsync());
            var validationResult = new CustomerRequestDTOValidator().Validate(dto);
            if (!validationResult.IsValid)
            {
                HttpResponseData error = req.CreateResponse(HttpStatusCode.BadRequest);
                await error.WriteStringAsync(validationResult.ToString());

                return error;
            }

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync("");

            return response;
        }
    }
}
