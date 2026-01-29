using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Pustok.Business.Dtos.CloudinaryDtos;
using Pustok.Business.Services.Abstractions;
using System.Net;
using System.IO;

namespace Pustok.Business.Services.Implementations;

internal class CloudinaryService : ICloudinaryService
{
    private readonly IConfiguration _configuration;
    private readonly CloudinaryOptionsDto _optionsDto;
    private readonly Cloudinary _cloudinary = null!;

    public CloudinaryService(IConfiguration configuration)
    {
        _configuration = configuration;
        _optionsDto = _configuration.GetSection("CloudinarySettings").Get<CloudinaryOptionsDto>() ?? new();

        var myAccount = new Account { ApiKey = _optionsDto.ApiKey, ApiSecret = _optionsDto.ApiSecret, Cloud = _optionsDto.CloudName };

        _cloudinary = new Cloudinary(myAccount);
        _cloudinary.Api.Secure = true;
    }

    public async Task<string> FileCreateAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Image file is required");

        string extension = Path.GetExtension(file.FileName);
        string fileName = $"{Guid.NewGuid()}{extension}";

        using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(fileName, stream),
            Folder = "MPA201-Pustok"
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        // Provide diagnostic details if upload failed
        if (uploadResult.Error != null)
        {
            var errMsg = $"Cloudinary upload failed: {uploadResult.Error.Message}";
            // Log for server console and then throw with details
            Console.WriteLine(errMsg);
            throw new Exception(errMsg);
        }

        // Some SDK versions may not set Error but SecureUrl could be null
        if (uploadResult.SecureUrl == null)
        {
            var status = uploadResult.StatusCode;
            var statusText = status != null ? status.ToString() : "unknown";
            var errMsg = $"Cloudinary upload failed: secure url null (HTTP status: {statusText})";
            Console.WriteLine(errMsg);
            throw new Exception(errMsg);
        }

        return uploadResult.SecureUrl.ToString();
    }

    public async Task<bool> FileDeleteAsync(string filePath)
    {
        try
        {
            string publicIdWithExtension = filePath.Substring(filePath.LastIndexOf("MPA201-Pustok"));
            string publicId = publicIdWithExtension.Substring(0, publicIdWithExtension.LastIndexOf('.'));

            var deleteParams = new DelResParams()
            {
                PublicIds = new List<string> { publicId },
                Type = "upload",
                ResourceType = ResourceType.Image
            };
            var result = await _cloudinary.DeleteResourcesAsync(deleteParams);

            return result.StatusCode == HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}