using System;
using System.Text.Json;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class HousePrice : IEquatable<HousePrice>
    {
        public bool Equals(HousePrice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(LocalAuthorityDistrict, other.LocalAuthorityDistrict) && Equals(Ward, other.Ward) && AverageHousePrice.Equals(other.AverageHousePrice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HousePrice) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocalAuthorityDistrict, Ward, AverageHousePrice);
        }

        public LocalAuthorityDistrict LocalAuthorityDistrict { get; set; }
        public Ward Ward { get; set; }
        public double AverageHousePrice { get; set; }
        
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