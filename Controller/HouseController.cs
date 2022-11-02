using System.Net;
using BMH.Domain.DTO;
using BMH.Domain.Models;
using BMH.Service;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using BMH.Domain;

namespace BMH.Controller
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
        public HttpResponseData GetHouses([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "house")] HttpRequestData req, HouseFilterQuery query)
        {
            List<HouseResponseDTO> responseDTO = new();

            List<House> houses = _houseService.GetHousesInPriceRange(query);

            foreach (House house in houses)
            {
                responseDTO.Add(new(house, _houseService.GetHouseImages(house)));
            }

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(responseDTO);

            return response;
        }
    }
}
