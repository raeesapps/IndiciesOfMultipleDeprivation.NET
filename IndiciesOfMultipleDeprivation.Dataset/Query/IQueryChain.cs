using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Queries
{
    public interface IQueryChain
    {
        public void Execute(IEnumerable<object> input, Dataset dataset);
    }
}