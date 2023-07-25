using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Interfaces.Common;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Services.Common;

public class VideoProtsesService : IVideoProtsesService
{
    private StorageClient _storageClient;
    private string bucketName = "course_zone";

    public VideoProtsesService()
    {
        GoogleCredential credentials;

        credentials = GoogleCredential.FromFile("C:/Users/Ahadulla/Downloads/secret1.json");

        _storageClient = StorageClient.Create(credentials);
    }

    public async Task<bool> VideoDeleteAsync(string subPath)
    {

        string objectName = subPath;

        await _storageClient.DeleteObjectAsync(bucketName, objectName);

        return true;
    }

    public async Task<string> VideoUploadAsync(IFormFile video)
    {

        string objectName = MediaHelper.MakeVideoName(video.FileName);

        using (var memoryStream = new MemoryStream())
        {
            await video.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            var storageObject = await _storageClient.UploadObjectAsync(bucketName, objectName, null, memoryStream);
            return storageObject.SelfLink;
        }

    }
}
