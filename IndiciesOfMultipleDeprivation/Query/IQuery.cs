using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Query
{
    public interface IQuery
    {
        public IEnumerable<object> Compute(IEnumerable<object> input, Dataset dataset);
    }
}