namespace CourseZone.Domain.Entites.Orders;

public class Order : BaseEntity
{
    public long UserId { get; set; }

    public long CourseId { get; set; }

    public DateTime CreateAt { get; set; }
}
