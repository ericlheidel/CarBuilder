namespace CarBuilder.Models;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public int WheelId { get; set; }
    public int TechnologyId { get; set; }
    public int PaintColorId { get; set; }
    public int InteriorId { get; set; }
    public WheelDTO? Wheel { get; set; }
    public TechnologyDTO? Technology { get; set; }
    public PaintColorDTO? PaintColor { get; set; }
    public InteriorDTO? Interior { get; set; }
}