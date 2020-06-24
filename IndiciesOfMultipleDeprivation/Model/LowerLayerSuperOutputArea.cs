using System;
using System.Text.Json;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class LowerLayerSuperOutputArea : IEquatable<LowerLayerSuperOutputArea>
    {
        public bool Equals(LowerLayerSuperOutputArea other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && Name == other.Name && Equals(LocalAuthorityDistrict, other.LocalAuthorityDistrict) && Equals(IndexOfMultipleDeprivation, other.IndexOfMultipleDeprivation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LowerLayerSuperOutputArea) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Name, LocalAuthorityDistrict, IndexOfMultipleDeprivation);
        }

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