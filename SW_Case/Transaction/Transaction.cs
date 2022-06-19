using System.Reflection.Metadata.Ecma335;
using SW_Case.Models;

namespace SW_Case;

public class Transaction
{
    public IList<Material> Materials { get; set; }
    public IList<Material> MaterialsWithPrice = new List<Material>();
    IList<Material> CheapestMaterials = new List<Material>();
    
    public  IList<Vendor> Vendors { get; set; }
    public IList<Material> NameMaterials = new List<Material>();
    public IList<Vendor> VendorsEco = new List<Vendor>();
    public IList<Material> NameEco = new List<Material>();
    public IList<Material> MeltingPoints = new List<Material>();
    public IList<Material> EcoMeltings = new List<Material>();
    public Material Material;


    //Task2:
    
    //Converting all the curencies into dkk.
    public double toDKK(string currency, double value)
    {
        switch (currency)
        {
            case "USD":
                return value * 7.09;
            case "POUND":
                return value * 8.67;
            case "EURO":
                return value * 7.44;
            default:
                return value;
        }
    }

    
    //Converting all lbs into kg
    public double toKG(string unit, double value)
    {
        switch (unit)
        {
            case "lbs":
                return value * 0.45;
            default:
                return value;
        }
    }

    
    //Getting the names for the materials
    public IList<Material> GetNames()
    {
        for (int i = 0; i <= Materials.Count; i++)
        {
            var mat = new Material();
            mat.Name = Materials[i].Name;
            mat.VendorId = Materials[i].VendorId;
            mat.DkkPrice = toKG(Materials[i].Unit, toDKK(Materials[i].Currency, Materials[i].PricePerUnit));
            MaterialsWithPrice.Add(mat);
        }

        return MaterialsWithPrice;
    }

    
    //Getting the cheapest material for each of them.
    public IList<Material> GetCheapest()
    {
        foreach (var material in MaterialsWithPrice)
        {
            bool exists = false;

            foreach (var variable in CheapestMaterials)
            {
                if (material.Name.Equals(variable.Name))
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                CheapestMaterials.Add(material);
            }
        }

        foreach (var material in CheapestMaterials)
        {
            foreach (var variable in MaterialsWithPrice)
            {
                if (material.Name.Equals(variable.Name) && (material.DkkPrice > variable.DkkPrice) && (material.DeliveryTimeDays.Equals(variable.DeliveryTimeDays)))
                {
                    material.DkkPrice = variable.DkkPrice;
                    material.VendorId = variable.VendorId;
                    material.DeliveryTimeDays = variable.DeliveryTimeDays;
                }
            }
        }

        return CheapestMaterials;
    }
    
    
    //Task3: 
    
    
    //Get the materials with the required name.
    public IList<Material> GetMaterialName()
    {
        foreach (var item in Materials)
        {
            if (item.Name.Equals("Polymethyl Methacrylate"))
            {
                NameMaterials.Add(item);
            }
        }

        return NameMaterials;
    }
    
    //Get Eco Vendors
    
    public IList<Vendor> GetEcoFriendly()
    {
        foreach (var variable in Vendors)
            {
                if ((variable.ECOFriendly.Equals("true")))
                {
                    VendorsEco.Add(variable);
                }
            }

        return VendorsEco;
    }

    //Get the cheapest Eco
    public IList<Material> GetCheapestEco()
    {
        foreach (var item in NameMaterials)
        {

            foreach (var vendor in VendorsEco)
            {
                if (item.VendorId == vendor.ID)
                {
                    NameEco.Add(item); 
                }
            }
        }

        return NameEco;
    }

    //Get Material for the required melting point
    public IList<Material> GetMeltingPoint()
    {
        foreach (var item in Materials)
        {
            if ((item.MeltingPoint <= 300) && (item.MeltingPoint >= 200))
            {
                MeltingPoints.Add(item);
            }
        }

        return MeltingPoints;
    }

    
    //Get the Eco Materials with the required melting point.
    public IList<Material> GetEcoMelting()
    {
        foreach (var item in NameEco)
        {
            foreach (var material in MeltingPoints)
            {
                if (item.ID == material.ID)
                {
                    EcoMeltings.Add(item);
                }
            }
        }

        return EcoMeltings;
    }
    
    //Get Cheapest EcoMelting.
    public Material GetCheapestMaterial()
    {
        double minim = 0;
        
        for (int i = 0; i <= EcoMeltings.Count; i++)
        {
            if (minim > EcoMeltings[i].DkkPrice)
            {
                Material.DkkPrice = EcoMeltings[i].DkkPrice;
            }
        }
        
        return Material;
    }
    
    //Or you can get the  fastest delivery time for the EcoMeltingMaterial.
    public Material GetFastDeliveryMaterial()
    {
        int minim = 0;

        for (int i = 0; i <= EcoMeltings.Count; i++)
        {
            if (minim > EcoMeltings[i].DeliveryTimeDays)
            {
                Material.DeliveryTimeDays = EcoMeltings[i].DeliveryTimeDays;
            }
        }

        return Material;
    }
}
    