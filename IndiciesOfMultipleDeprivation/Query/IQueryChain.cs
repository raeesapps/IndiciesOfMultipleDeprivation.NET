using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Model;

namespace IndiciesOfMultipleDeprivation.Query
{
    public interface IQueryChain
    {
        public IList<IQuery> Queries { get; set; }
        public IEnumerable<object> Execute(IEnumerable<object> input, Dataset dataset);
    }
}