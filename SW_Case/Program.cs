using SW_Case;
using SW_Case.Models;

class Program
{
    static void Main(string[] args)
    {
        Material material1 = new Material();
        material1.ID = 22;
        material1.Name = "Polymethyl Methacrylate";
        material1.VendorId = 11;
        material1.Color = "Aero";
        material1.PricePerUnit = 20;
        material1.Currency = "EURO";
        material1.Unit = "lbs";
        material1.MeltingPoint = 230;
        material1.TempUnit = "C";
        material1.DeliveryTimeDays = 42;


        Material material2 = new Material();
        material2.ID = 24;
        material2.Name = "Polypropylene (PP)";
        material2.VendorId = 4;
        material2.Color = "Blue";
        material2.PricePerUnit = 5;
        material2.Currency = "POUND";
        material2.Unit = "kg";
        material2.MeltingPoint = 421;
        material2.TempUnit = "F";
        material2.DeliveryTimeDays = 34;


        Vendor vendor1 = new Vendor();
        vendor1.ID = 4;
        vendor1.Name = "Balmy Orange";
        vendor1.PostalCode = 5177;
        vendor1.Address =  "268 Is Ally";
        vendor1.ContactPerson = "Lars";
        vendor1.ECOFriendly = true;

        Vendor vendor2 = new Vendor();
        vendor2.ID = 11;
        vendor2.Name = "Bracing Vej Best";
        vendor2.PostalCode = 1774;
        vendor2.Address = "529 Odin Street";
        vendor2.ContactPerson = "Allen";
        vendor2.ECOFriendly = false;

        Items items = new Items();
        items.Materials.Add(material1);
        items.Materials.Add(material2);
        
        items.Vendors.Add(vendor1);
        items.Vendors.Add(vendor2);
        
        Transaction transaction = new Transaction();
        transaction.Materials = new List<Material>();
        transaction.Materials.Add(material1);
        transaction.Materials.Add(material2);
        
        transaction.Vendors = new List<Vendor>();
        transaction.Vendors.Add(vendor1);
        transaction.Vendors.Add(vendor2);


        foreach (var item in transaction.GetMaterialName())
        {
            Console.WriteLine(item.Name);
            //Returns Polymethyl Methacrylate
        }

        foreach (var item in transaction.GetMeltingPoint())
        {
            Console.WriteLine(item.MeltingPoint);
            //Returns 230.
        }

    }

}
