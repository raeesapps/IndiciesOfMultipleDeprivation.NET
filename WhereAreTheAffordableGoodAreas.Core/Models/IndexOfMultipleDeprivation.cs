using System.Text.Json;

namespace WhereAreTheAffordableGoodAreas.Models
{
    public class IndexOfMultipleDeprivation
    {
        public string Rank { get; set; }
        public string Decile { get; set; }
        
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