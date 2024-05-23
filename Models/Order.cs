namespace CarBuilder.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime? TimeStamp { get; set; }
    public int WheelId { get; set; }
    public int TechnologyId { get; set; }
    public int PaintColorId { get; set; }
    public int InteriorId { get; set; }
    public Wheel? Wheel { get; set; }
    public Technology? Technology { get; set; }
    public PaintColor? PaintColor { get; set; }
    public Interior? Interior { get; set; }
    public bool Fulfilled
    {
        get
        {
            if (TimeStamp != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public decimal TotalCost
    {
        get
        {
            decimal total = 0;

            if (Wheel != null)
            {
                total += Wheel.Price;
            }

            if (Technology != null)
            {
                total += Technology.Price;
            }

            if (PaintColor != null)
            {
                total += PaintColor.Price;
            }

            if (Interior != null)
            {
                total += Interior.Price;
            }

            return total;
        }
    }
}