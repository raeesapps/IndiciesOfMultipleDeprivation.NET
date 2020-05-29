using System.Text.Json;

namespace WhereAreTheAffordableGoodAreas.Models
{
    public class Ward
    {
        public string Name { get; set; }
        public string Code { get; set; }
        
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