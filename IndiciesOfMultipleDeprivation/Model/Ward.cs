using System;
using System.Text.Json;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class Ward : IEquatable<Ward>
    {
        public bool Equals(Ward other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Code == other.Code;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ward) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Code);
        }

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