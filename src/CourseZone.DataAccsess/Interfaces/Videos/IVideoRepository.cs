using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.Domain.Entites.Videas;

namespace CourseZone.DataAccsess.Interfaces.Videos;

public interface IVideoRepository : IRepository<Video, Video> ,IGetAll<Video>, ISearchable<Video>
{
}
