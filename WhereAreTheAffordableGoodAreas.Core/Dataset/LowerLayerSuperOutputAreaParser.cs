using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using WhereAreTheAffordableGoodAreas.Models;

namespace WhereAreTheAffordableGoodAreas.Dataset
{
    public class LowerLayerSuperOutputAreaParser
    {
        private readonly string _path;

        public LowerLayerSuperOutputAreaParser(string path)
        {
            _path = path;
        }

        public IEnumerable<LowerLayerSuperOutputArea> Parse()
        {
            var _lowerLayerSuperOutputAreas = new List<LowerLayerSuperOutputArea>();

            using var csvParser = new TextFieldParser(_path);
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                var fields = csvParser.ReadFields();

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
                    Rank = indexOfMultipleDeprivationRank,
                    Decile = indexOfMultipleDeprivationDecile,
                };

                var lowerLayerSuperOutputArea = new LowerLayerSuperOutputArea
                {
                    Code = lowerLayerSuperOutputAreaCode,
                    Name = lowerLayerSuperOutputAreaName,
                    LocalAuthorityDistrict = localAuthorityDistrict,
                    IndexOfMultipleDeprivation = indexOfMultipleDeprivation,
                };
                    
                _lowerLayerSuperOutputAreas.Add(lowerLayerSuperOutputArea);
            }

            return _lowerLayerSuperOutputAreas;
        }
    }
}
