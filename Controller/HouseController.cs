using System.Net;
using Azure;
using BMH.Service.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Repository;
using VRefSolutions.Domain.Models;

namespace BMH
{
    public class HouseController
    {
        private readonly ILogger _logger;
        private IHouseService _houseService { get; }

        public HouseController(ILoggerFactory loggerFactory, IHouseService houseService)
        {
            _logger = loggerFactory.CreateLogger<HouseController>();
            _houseService = houseService;
        }

        [Function(nameof(HouseController.GetHouses))]
        public HttpResponseData GetHouses([HttpTrigger(AuthorizationLevel.Function, "get", Route = "house")] HttpRequestData req, HouseFilterQuery filterQuery)
        {
            List<House> houses = _houseService.GetHousesInPriceRange(filterQuery);

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(houses);

            return response;
        }
    }
}
