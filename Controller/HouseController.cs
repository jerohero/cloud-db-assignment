using System.Net;
using Domain.DTO;
using Domain.Entity;
using Domain.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Service.Interface;

namespace Controller
{
    public class HouseController
    {
        private readonly ILogger _logger;
        private IHouseService HouseService { get; }

        public HouseController(ILoggerFactory loggerFactory, IHouseService houseService)
        {
            _logger = loggerFactory.CreateLogger<HouseController>();
            HouseService = houseService;
        }

        [Function(nameof(GetHouses))]
        public HttpResponseData GetHouses([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "house")] HttpRequestData req, HouseFilterQuery query)
        {
            IEnumerable<House> houses = HouseService.GetHousesInPriceRange(query);

            List<HouseResponseDto> responseDto = houses.Select(house => 
                new HouseResponseDto(house, HouseService.GetHouseImages(house))
            ).ToList();

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(responseDto);

            return response;
        }
    }
}
