namespace SW_Case.Models;

public class Material
{
    public int ID { get; set; }
    public int VendorId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public double PricePerUnit { get; set; }
    public string Currency { get; set; }
    public string Unit { get; set; }
    public double MeltingPoint { get; set; }
    public string TempUnit { get; set; }
    public int DeliveryTimeDays { get; set; }
    public double DkkPrice { get; set; }
    public double toKg { get; set; }
}