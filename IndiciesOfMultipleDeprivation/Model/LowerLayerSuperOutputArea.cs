using System.Text.Json;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class LowerLayerSuperOutputArea
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public LocalAuthorityDistrict LocalAuthorityDistrict { get; set; }
        public IndexOfMultipleDeprivation IndexOfMultipleDeprivation { get; set; }
        
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