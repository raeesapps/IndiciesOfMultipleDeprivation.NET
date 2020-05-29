using System.Collections.Generic;

namespace WhereAreTheAffordableGoodAreas.Dataset
{
    public interface IParser<T>
    {
        public IEnumerable<T> Parse();
    }
}
