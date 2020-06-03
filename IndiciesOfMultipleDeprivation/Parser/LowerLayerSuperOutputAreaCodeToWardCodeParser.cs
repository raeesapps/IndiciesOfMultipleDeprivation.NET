using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using Microsoft.VisualBasic.FileIO;

namespace IndiciesOfMultipleDeprivation.Parser
{
    public class LowerLayerSuperOutputAreaCodeToWardCodeParser : CsvParser<string, string>
    {
        public LowerLayerSuperOutputAreaCodeToWardCodeParser(
            [KeyFilter("lowerLayerSuperOutputAreaCodeToWardCodeDatasetPath")]
            TextFieldParser textFieldParser) : base(textFieldParser)
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