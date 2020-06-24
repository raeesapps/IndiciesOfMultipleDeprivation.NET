using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Model;
using IndiciesOfMultipleDeprivation.Parser;
using NSubstitute;
using NUnit.Framework;

namespace IndiciesOfMultipleDeprivation.Tests.Parser
{
    public class LowerLayerSuperOutputAreaParserShould
    {
        private readonly ITextFieldParser _textFieldParser;
        private readonly ILinearParser<LowerLayerSuperOutputArea> _lowerLayerSuperOutputAreaParser;

        public LowerLayerSuperOutputAreaParserShould()
        {
            _textFieldParser = Substitute.For<ITextFieldParser>();
            _lowerLayerSuperOutputAreaParser = new LowerLayerSuperOutputAreaParser(_textFieldParser);
        }

        [Test]
        public void ParseLowerLayerSuperOutputAreaCsvRowMatchesExpectedLowerLayerSuperOutputAreaDao()
        {
            var lowerLayerSuperOutputAreaRowFields =
                "E01000001,City of London 001A,E09000001,City of London,29199,9".Split(',');
            var expectedLowerLayerSuperOutputArea = new LowerLayerSuperOutputArea
            {
                Code = "E01000001",
                Name = "City of London 001A",
                IndexOfMultipleDeprivation = new IndexOfMultipleDeprivation
                {
                    Decile = 9,
                    Rank = 29199,
                },
                LocalAuthorityDistrict = new LocalAuthorityDistrict
                {
                    Code = "E09000001",
                    Name = "City of London",
                }
            };
            var expectedList = new List<LowerLayerSuperOutputArea> {expectedLowerLayerSuperOutputArea};
            _textFieldParser.ReadFields().Returns(lowerLayerSuperOutputAreaRowFields)
                .AndDoes((action) => _textFieldParser.EndOfData.Returns(true));

            var actualList = _lowerLayerSuperOutputAreaParser.Parse();
            
            Assert.AreEqual(expectedList, actualList);
        }
    }
}
