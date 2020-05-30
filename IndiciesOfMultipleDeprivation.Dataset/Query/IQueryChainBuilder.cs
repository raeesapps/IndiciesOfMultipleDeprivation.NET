using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Queries
{
    public interface IQueryChainBuilder
    {
        public IList<IQuery> Queries { get; set; }
        public IQueryChain Build();
        public IQueryChainBuilder Add(IQuery query);
    }
}