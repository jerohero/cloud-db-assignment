using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BMH.Repository.Interfaces;
using BMH.Domain;
using BMH.Domain.Models;

namespace BMH.Service
{
    public class HouseService : IHouseService
    {
        private const string HOUSES_IMAGES_BLOB_CONTAINER = "houses-images";
        private readonly string _connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process);
        private IHouseRepository _houseRepository { get; }
        private BlobServiceClient _blobServiceClient { get; }
        private BlobContainerClient _blobContainerClient { get; }
        private string _containerUrl { get; }

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
            _blobServiceClient = new(_connectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(HOUSES_IMAGES_BLOB_CONTAINER);
            _containerUrl = _blobContainerClient.Uri.ToString();
        }

        public List<House> GetHousesInPriceRange(HouseFilterQuery filter)
        {
            int minPrice = filter?.MinPrice ?? 0;
            int maxPrice = filter?.MaxPrice ?? int.MaxValue;

            return _houseRepository
                .GetAll()
                .Where(o => o.Price >= minPrice && o.Price <= maxPrice)
                .ToList();
        }

        public List<string> GetHouseImages(House house)
        {
            List<string> images = new();
            string blobPath = $"{house.City}/{house.Id}";

            Pageable<BlobItem> blobs = _blobContainerClient.GetBlobs(prefix: blobPath);

            foreach (BlobItem blob in blobs)
            {
                images.Add($"{_containerUrl}/{blob.Name}");
            }

            return images;
        }
    }
}