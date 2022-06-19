using System.Text.Json;
using SW_Case.Models;

namespace SW_Case;

public class Importer
{
    public Items ItemList { get; set; }

    private readonly string items = "material_vendor_data.json";

    public Importer()
    {
        ItemList = File.Exists(items) ? ReadData(items) : new Items();
    }

    private Items ReadData(string fileName)
    {
        //for closing the file automatically
        using (var jsonReader = File.OpenText(fileName))
        {
            return JsonSerializer.Deserialize<Items>(jsonReader.ReadToEnd());
        }
    }
}