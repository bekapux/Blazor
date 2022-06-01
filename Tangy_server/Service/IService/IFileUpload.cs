using Microsoft.AspNetCore.Components.Forms;

namespace Tangy_server.IService.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string filePath);
    }
}
