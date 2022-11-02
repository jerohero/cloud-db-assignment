using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Entity;
using Domain.Model;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class HouseService : IHouseService
    {
        private const string HousesImagesBlobContainer = "houses-images";
        private readonly string _connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process);
        private IHouseRepository HouseRepository { get; }
        private BlobServiceClient BlobServiceClient { get; }
        private BlobContainerClient BlobContainerClient { get; }
        private string ContainerUrl { get; }

        public HouseService(IHouseRepository houseRepository)
        {
            HouseRepository = houseRepository;
            BlobServiceClient = new BlobServiceClient(_connectionString);
            BlobContainerClient = BlobServiceClient.GetBlobContainerClient(HousesImagesBlobContainer);
            ContainerUrl = BlobContainerClient.Uri.ToString();
        }

        public IEnumerable<House> GetHousesInPriceRange(HouseFilterQuery filter)
        {
            int minPrice = int.TryParse(filter?.Min, out minPrice) ? minPrice : 0;
            int maxPrice = int.TryParse(filter?.Max, out maxPrice) ? minPrice : int.MaxValue;

            return HouseRepository
                .GetAll()
                .Where(o => o.Price >= minPrice && o.Price <= maxPrice)
                .ToList();
        }

        public List<string> GetHouseImages(House house)
        {
            string blobPath = $"{house.City}/{house.Id}";

            Pageable<BlobItem> blobs = BlobContainerClient.GetBlobs(prefix: blobPath);

            return blobs.Select(blob => $"{ContainerUrl}/{blob.Name}").ToList();
        }
    }
}