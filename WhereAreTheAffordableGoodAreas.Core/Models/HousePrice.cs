using System.Text.Json;

namespace WhereAreTheAffordableGoodAreas.Models
{
    public class HousePrice
    {
        public LocalAuthorityDistrict LocalAuthorityDistrict { get; set; }
        public Ward Ward { get; set; }
        public string AverageHousePrice { get; set; }
        
        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            
            return JsonSerializer.Serialize(this, options);
        }
    }
}