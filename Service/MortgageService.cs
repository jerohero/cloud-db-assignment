using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Domain.Entity;
using Domain.Model;
using Microsoft.Extensions.Logging;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Repository;
using Repository.Interface;
using Service.Interface;
using System.Text;

namespace Service
{
    public class MortgageService : IMortgageService
    {
        private const string MortgageOffersBlobContainer = "mortgage-offers";
        private readonly string _connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage", EnvironmentVariableTarget.Process);
        private ICustomerService CustomerService { get; }
        private BlobServiceClient BlobServiceClient { get; }
        private BlobContainerClient BlobContainerClient { get; }
        private string ContainerUrl { get; }
        private ILogger _logger { get; set; }

        public MortgageService(ICustomerService customerService, ILoggerFactory loggerFactory)
        {
            BlobServiceClient = new BlobServiceClient(_connectionString);
            BlobContainerClient = BlobServiceClient.GetBlobContainerClient(MortgageOffersBlobContainer);
            ContainerUrl = BlobContainerClient.Uri.ToString();
            CustomerService = customerService;
            _logger = loggerFactory.CreateLogger<MortgageService>();
        }

        public void GenerateUserMortgageDocuments()
        {
            List<Customer> customers = CustomerService.GetAll();

            foreach (Customer customer in customers)
            {
                int mortgage = CalculateMortgage(customer.Income);

                PdfDocument pdf = GenerateMortgagePdf(mortgage, customer);
                MemoryStream stream = new MemoryStream();
                pdf.Save(stream, false);

                BlobClient blobClient = BlobContainerClient.GetBlobClient($"{customer.Id}/mortgage.pdf");
                blobClient.UploadAsync(stream, true);
            }
        }

        public int CalculateMortgage(int income)
        {
            return (int)(income * 2.24);
        }

        private PdfDocument GenerateMortgagePdf(int mortgage, Customer customer)
        {
            PdfDocument document = new();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont fontTitle = new XFont("Verdana", 20, XFontStyle.Bold);
            XFont fontText = new XFont("Verdana", 15, XFontStyle.Regular);
            gfx.DrawString("Your maximum mortgage has been calculated", fontTitle, XBrushes.Black, new XRect(0, 100, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"Name: {customer.Name}", fontText, XBrushes.Black, new XRect(0, 150, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"Income: €{customer.Income} / year", fontText, XBrushes.Black, new XRect(0, 150, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"Maximum mortgage: €{mortgage}", fontText, XBrushes.Black, new XRect(0, 180, page.Width, page.Height), XStringFormats.TopCenter);

            return document;
        }
    }
}