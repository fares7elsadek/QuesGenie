using Microsoft.AspNetCore.Http;

namespace QuesGenie.Application.Services.Files;

public interface IFileService
{
    Task<(string,string)> SaveFileAsync(IFormFile file);
    Task DeleteFile(string FileName);
}