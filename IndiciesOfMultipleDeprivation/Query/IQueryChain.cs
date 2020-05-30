using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Models;

namespace IndiciesOfMultipleDeprivation.Query
{
    public interface IQueryChain
    {
        public IEnumerable<object> Execute(IEnumerable<object> input, Dataset dataset);
    }
}