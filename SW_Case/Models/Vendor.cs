namespace SW_Case.Models;

public class Vendor
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int PostalCode { get; set; }
    public string Address { get; set; }
    public string ContactPerson { get; set; }
    public bool ECOFriendly { get; set; }
}