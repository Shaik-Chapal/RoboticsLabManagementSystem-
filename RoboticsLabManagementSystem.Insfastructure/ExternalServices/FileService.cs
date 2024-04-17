
using RoboticsLabManagementSystem.Application.ExternalServices;

namespace RoboticsLabManagementSystem.Infrastructure.ExternalServices
{
    //public class FileService : IFileService
    //{
    //    private readonly IFileStorageService _fileStorageService;
    //    private readonly IFileStoragePathService _fileStoragePathService;
    //    public FileService(IFileStorageService fileStorageService,IFileStoragePathService fileStoragePathService)
    //    {
    //        _fileStorageService = fileStorageService;
    //        _fileStoragePathService = fileStoragePathService;
    //    }

    //    public async Task<string> UploadFile(string base64File, string fileKey)
    //    {
    //        var result = await _fileStorageService.UploadAsync(base64File, fileKey);
    //        return result;
    //    }

    //    public string GetFileUrl(string fileName, string defaultFile)
    //    {
    //        return _fileStoragePathService.GetFileUrl(fileName,defaultFile);
    //    }

    //    public async Task DeleteFile(string fileName)
    //    {
    //        await _fileStorageService.DeleteAsync(fileName);
    //    }
    //}
}
