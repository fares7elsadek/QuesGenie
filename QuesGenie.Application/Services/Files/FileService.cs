using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Helpers;

namespace QuesGenie.Application.Services.Files;

public class FileService(IOptions<BlobStorageOptions> blobOptions):IFileService
{
    private readonly BlobStorageOptions _options = blobOptions.Value;
    public async Task<(string, string)> SaveFileAsync(IFormFile file)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));

        var ext = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid().ToString()}{ext}";
        Console.WriteLine(_options.ConnectionString);
        var blobServiceClient = new BlobServiceClient(_options.ConnectionString);
        var blobContainer = blobServiceClient.GetBlobContainerClient(_options.PhotosContainerName);
        await blobContainer.CreateIfNotExistsAsync();
        var blobClient = blobContainer.GetBlobClient(fileName);

        await using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, true);
        }

        return (blobClient.Uri.ToString(), fileName);
    }

    public async Task DeleteFile(string FileName)
    {
        var blobServiceClient = new BlobServiceClient(_options.ConnectionString);
        var blobContainer = blobServiceClient.GetBlobContainerClient(_options.PhotosContainerName);
        var blobClient = blobContainer.GetBlobClient(FileName);
        await blobClient.DeleteIfExistsAsync();
    }
}