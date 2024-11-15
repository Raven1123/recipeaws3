
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Recipe1.api.ImageService
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<byte[]> DownloadFileAsync(string fileKey);
    }
}
