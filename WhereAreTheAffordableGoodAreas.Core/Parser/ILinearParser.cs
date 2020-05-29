using System.Collections.Generic;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public interface ILinearParser<T>
    {
        public IList<T> Parse();
    }
}
