using System.Collections.Generic;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public interface IParser<T>
    {
        public IEnumerable<T> Parse();
    }
}
