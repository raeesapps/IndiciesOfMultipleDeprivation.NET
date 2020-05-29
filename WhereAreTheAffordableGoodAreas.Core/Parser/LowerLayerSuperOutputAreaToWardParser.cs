using System.Collections.Generic;

namespace WhereAreTheAffordableGoodAreas.Parser
{
    public class LowerLayerSuperOutputAreaToWardParser : CsvParser<string, string>
    {
        public LowerLayerSuperOutputAreaToWardParser(string path) : base(path)
        {
        }

        protected override void OnReadFields(IList<string> ks, string[] fields)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnReadFields(IDictionary<string, string> kvs, string[] fields)
        {
            var lowerLayerSupportAreaCode = fields[1];
            var ward = fields[3];
            kvs.Add(lowerLayerSupportAreaCode, ward);
        }
    }
}