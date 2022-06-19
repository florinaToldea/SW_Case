using SW_Case.Models;

namespace SW_Case.Sort;

public class Sort
{
    public IList<Material> Materials { get; set; }
    public  IList<Vendor> Vendors { get; set; }
    
    //Case1: Here we sort the json into materials and vendors separate list.
    public IList<Material> GetMaterials(Items items)
    {
        return items.Materials;
    }

    public IList<Vendor> GetVendors(Items items)
    {
        return items.Vendors;
    }
    
    
    
    //Case2: Returning materials for certain vendor id.
    public void PrintVendorMaterials()
    {
        foreach (var item in Vendors)
        {
            Console.WriteLine("The vendor name is: " + item.Name);
            GetVendorMaterials(item.ID);            
        }
    }
    public IList<Material> GetVendorMaterials(int id)
    {
        var list = new List<Material>();
        foreach (var item in Materials)
        {
            if (id == item.VendorId)
            {
                list.Add(item);
            }
        }

        return list;
    }
}