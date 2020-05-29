using System;
using System.Text.Json;

namespace WhereAreTheAffordableGoodAreas.Models
{
    public class LocalAuthorityDistrict : IEquatable<LocalAuthorityDistrict>
    {
        public bool Equals(LocalAuthorityDistrict other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LocalAuthorityDistrict) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Name);
        }

        public string Code { get; set; }
        public string Name { get; set; }
        
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