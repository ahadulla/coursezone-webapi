namespace CourseZone.Domain.Exceptions.Videos;

public class VideoNotFoundException : NotFoundException
{
    public VideoNotFoundException()
    {
        this.TitleMessage = "Video not found";
    }
}
