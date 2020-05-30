using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Query
{
    public interface IQueryChainBuilder
    {
        public IList<IQuery> Queries { get; set; }
        public IQueryChain Build();
        public IQueryChainBuilder Add(IQuery query);
    }
}