using System.Text.Json;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class IndexOfMultipleDeprivation
    {
        public int Rank { get; set; }
        public int Decile { get; set; }
        
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