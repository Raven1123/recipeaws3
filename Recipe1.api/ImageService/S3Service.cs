
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Recipe1.api.Controllers;
using Recipe1.api.ImageService;


namespace Recipe1.api.ImageService
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File cannot be null or empty");
            }

            using var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = file.FileName,
                BucketName = _bucketName,
                ContentType = file.ContentType
            };

            var fileTransferUtility = new TransferUtility(_s3Client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            return $"File '{file.FileName}' uploaded successfully to bucket '{_bucketName}'.";
        }

        public async Task<byte[]> DownloadFileAsync(string fileKey)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileKey
            };

            using (var response = await _s3Client.GetObjectAsync(request))
            using (var responseStream = response.ResponseStream)
            using (var memoryStream = new MemoryStream())
            {
                await responseStream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
