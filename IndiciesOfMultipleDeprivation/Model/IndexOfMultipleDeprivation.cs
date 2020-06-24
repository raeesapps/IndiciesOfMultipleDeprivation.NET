using System;
using System.Text.Json;

namespace IndiciesOfMultipleDeprivation.Model
{
    public class IndexOfMultipleDeprivation : IEquatable<IndexOfMultipleDeprivation>
    {
        public bool Equals(IndexOfMultipleDeprivation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Rank == other.Rank && Decile == other.Decile;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IndexOfMultipleDeprivation) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rank, Decile);
        }

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