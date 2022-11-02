using System.Net;
using AutoMapper;
using Controller.Validator;
using Domain.DTO;
using Domain.Entity;
using FluentValidation.Results;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.Interface;

namespace Controller
{
    public class CustomerController
    {
        private readonly ILogger _logger;
        private ICustomerService CustomerService { get; }
        private IMapper Mapper { get; }

        public CustomerController(ILoggerFactory loggerFactory, ICustomerService customerService, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<HouseController>();
            CustomerService = customerService;
            Mapper = mapper;
        }

        [Function(nameof(CreateCustomer))]
        public async Task<HttpResponseData> CreateCustomer([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "customer")] HttpRequestData req)
        {
            CustomerRequestDto dto = JsonConvert.DeserializeObject<CustomerRequestDto>(await new StreamReader(req.Body).ReadToEndAsync());
            ValidationResult validationResult = await new CustomerRequestDtoValidator().ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                HttpResponseData error = req.CreateResponse(HttpStatusCode.BadRequest);
                await error.WriteStringAsync(validationResult.ToString());

                return error;
            }

            Customer created = CustomerService.CreateCustomer(Mapper.Map<Customer>(dto));

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(Mapper.Map<CustomerResponseDto>(created));

            return response;
        }
    }
}
