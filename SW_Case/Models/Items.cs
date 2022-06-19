namespace SW_Case.Models;

public class Items
{
    public IList<Material> Materials { get; set; }
    public IList<Vendor> Vendors { get; set; }

    public Items()
    {
        Materials = new List<Material>();
        Vendors = new List<Vendor>();
    }
}