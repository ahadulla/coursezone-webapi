using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Interfaces.Common;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CourseZone.Service.Services.Common;

public class VideoProtsesService : IVideoProtsesService
{
    private readonly IConfiguration configuration;
    private StorageClient _storageClient;
    private string bucketName = "course_zone";

    public VideoProtsesService(IConfiguration configuration)
    {
        GoogleCredential credentials;
        this.configuration= configuration;

        credentials = GoogleCredential.FromJson("{\r\n    \"type\": \"service_account\",\r\n    \"project_id\": \"main-form-393712\",\r\n    \"private_key_id\": \"9d3d8d4870aaf4f7e79840c5a35a5a143cca293f\",\r\n    \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCnmxBWK1yxtD3P\\nFk4bjmasc0FzCKshvQt1Mxp2h0KBsduNqhkErEQHLiMtNnH6gduZ92/mbWiEiEQm\\nOT/kroI+R5alu4zoXUx6o6m1w5aJbruku2QQLA4rLGF85qLINsi/g5tJBTt7K4nS\\nEu7xgYdYjCKQYUgP3R8MIuDBSlDnFWtWqSFNIeekxQCcdv/h7ARun+Dd8/Pq0GX3\\ngBZWnV1s1HZ3RsfYDCC0iTVUxhWFfT98++zpKTxDO49AsK4D4dW44Q/jzfP2bRq/\\n7x99/bP3oBX4GvcqvNWa4mxSVK2WYlb6ew5TTuQ1W4TGI/OxhtPFq/kIPxwaalBp\\nTd18TbqPAgMBAAECggEAFD2DR99YA/8akRNGKXO/7cbED5/rXVlWtIzlqYyvY7mB\\nJGbMkKY7rOD4edxKVWXbNDO6aAmsW9zs20TXShwnjwfW0dAyta5BWcoWk48OyIKp\\nLGfo2enIEun6zTo49ulkGCSiMGZDsZ3SDfQgC5AzMmacl0ei4S+N2/RWT2FUdc4L\\n8xmj/vUuTFngj4HAJUoqiVPPcjptfrG0mYv0DLX6ROf9QsWX1e4t6mFB2SHV/Adg\\nl+xcOTx5c7MJ5X8EtiSp5ZKUBUelQQcDa0ewEFlttJoXtp7xD8JWxMVmEg8Fr7q2\\nvRjQOEffLZLeWLFB2Tf42OoLJ6z3WaewMMHCbmqsiQKBgQDaMJY6itJQT6OoV/U5\\nMIs9kRhuxBOf/yxKR5IR6Xxwo1Hwp2GWJIyGkjp555QNI7CuwhffPwnAxw3C+UtA\\n0vqek02XUK9zubUx5RH2qmtItdAwYnD/HBcvcSbfmAfXiP4ClG/8PZsfm32Bg0ax\\nbBPLByB6FkEv+4/zv8CMGSJRkwKBgQDEpnLDHZNsiuqmYekXRvWLHc0Hs6pynP1f\\n6IoiSvhPMEbWlrYs2pVKOGqFZT+aicG4T/HGNrMGNor39ifX1PDrBHAhKyhsvi53\\nV45ELfQPZHNoiDKLr1o7i7nXKdwbQpEzVgDOfRQJml9bkfmLYVk4OMDHZkMs01Vv\\nI6aCeQLAlQKBgQCsLsd+72pE4nQeNztXpE1dipEjaCysiGxlOdG1vPHs2ZWiOhSy\\nrakP0XnAFdYqAE4/uv+nt1F1BiCACscuItCQL2J91LiAtL6e30yrwZTkTkY6yJSv\\nXXWWhM7OiGU32+3ID2fIQL2X1dbXS8eP3+BGyhsA/Wr3+KeDDYFfjb4dbQKBgE5j\\nOyPjyjxeM6MXLF8G/iHyQyRqzeraAXYVr9pzn/+Q8uvfL8c5aoEnc+6wqWXku7/I\\nvkuQylQTsdmd2cwDKfXE0x2lonuWY9dWo3MyDjOEiyyD/gIIaCOMUwwdt4t2QYMB\\nKVkmKrKZQqGx0pNovrPWi6HwdZ6Mr2WaBGnF6v7xAoGBAK9KhK6vwN25y0rap2ci\\nzTJcrlwUqNLzCxDJko0rQgxHfd9F6VkQlYQ1SCjCwzXs+ILWm+yva2pAlXnhsMwv\\nIvgVOzR8mLSLwDYzFJ4jfDkwo3/QhDjMb/x/HsgXp4ugcutcu1/31qXMD0LD7I2K\\naxwZmEhOJBp1jVWsdUWhwRmF\\n-----END PRIVATE KEY-----\\n\",\r\n    \"client_email\": \"coursezone@main-form-393712.iam.gserviceaccount.com\",\r\n    \"client_id\": \"107507493698944737509\",\r\n    \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n    \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n    \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n    \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/coursezone%40main-form-393712.iam.gserviceaccount.com\",\r\n    \"universe_domain\": \"googleapis.com\"\r\n  }\r\n");
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
            return objectName;
        }

    }
}
