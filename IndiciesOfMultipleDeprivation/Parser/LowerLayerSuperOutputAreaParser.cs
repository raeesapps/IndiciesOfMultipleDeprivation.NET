using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using IndiciesOfMultipleDeprivation.Model;
using Microsoft.VisualBasic.FileIO;

namespace IndiciesOfMultipleDeprivation.Parser
{
    public class LowerLayerSuperOutputAreaParser : CsvParser<LowerLayerSuperOutputArea, object>
    {
        protected override void OnReadFields(IList<LowerLayerSuperOutputArea> ts, string[] fields)
        {
            var lowerLayerSuperOutputAreaCode = fields[0];
            var lowerLayerSuperOutputAreaName = fields[1];

            var localAuthorityDistrictCode = fields[2];
            var localAuthorityDistrictName = fields[3];
            var localAuthorityDistrict = new LocalAuthorityDistrict
            {
                Code = localAuthorityDistrictCode,
                Name = localAuthorityDistrictName
            };

            var indexOfMultipleDeprivationRank = fields[4];
            var indexOfMultipleDeprivationDecile = fields[5];
            
            var indexOfMultipleDeprivation = new IndexOfMultipleDeprivation
            {
                Rank = int.Parse(indexOfMultipleDeprivationRank.Replace(",", "")),
                Decile = int.Parse(indexOfMultipleDeprivationDecile.Replace(",", "")),
            };

            var lowerLayerSuperOutputArea = new LowerLayerSuperOutputArea
            {
                Code = lowerLayerSuperOutputAreaCode,
                Name = lowerLayerSuperOutputAreaName,
                LocalAuthorityDistrict = localAuthorityDistrict,
                IndexOfMultipleDeprivation = indexOfMultipleDeprivation,
            };
                    
            ts.Add(lowerLayerSuperOutputArea);
        }

        protected override void OnReadFields(IDictionary<LowerLayerSuperOutputArea, object> kvs, string[] fields)
        {
            throw new System.NotImplementedException();
        }

        public LowerLayerSuperOutputAreaParser([KeyFilter("lowerLayerSuperOutputAreaDatasetPath")]
            TextFieldParser textFieldParser) : base(textFieldParser)
        {
            
        }
    }
}
