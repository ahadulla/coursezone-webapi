namespace CourseZone.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid()+extension;
        return name;
    }

    public static string MakeVideoName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "VIDEO_" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            // JPG files
            ".jpg", ".jpeg",
            // Png files
            ".png",
            // Bmp files
            ".bmp",
            // Svg files
            ".svg"
        };
    }

    public static string[] GetVideoExtensions()
    {
        return new string[]
        {
            // mp4 files
            ".mp4",
            // mkv files
            ".mkv",
        };
    }
}
