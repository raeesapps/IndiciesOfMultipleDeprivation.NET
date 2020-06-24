using System.Collections.Generic;
using IndiciesOfMultipleDeprivation.Parser;
using NSubstitute;
using NUnit.Framework;

namespace IndiciesOfMultipleDeprivation.Tests.Parser
{
    public class LowerLayerSuperOutputAreaCodeToWardCodeParserShould
    {
        private readonly ITextFieldParser _textFieldParser;
        private readonly IKeyValueParser<string, string> _lowerLayerSuperOutputAreaCodeToWardCodeParser;

        public LowerLayerSuperOutputAreaCodeToWardCodeParserShould()
        {
            _textFieldParser = Substitute.For<ITextFieldParser>();
            _lowerLayerSuperOutputAreaCodeToWardCodeParser =
                new LowerLayerSuperOutputAreaCodeToWardCodeParser(_textFieldParser);
        }

        [Test]
        public void ParseLsoaToWardCodeCsvRowMatchesLsoaToWardCodeKvPair()
        {
            var lsoaToWardCodeRowFields =
                "157,E01011954,Hartlepool 001A,E05008943,De Bruce,E06000001,Hartlepool".Split(",");
            var expectedDictionary = new Dictionary<string, string>
            {
                {"E01011954", "E05008943"},
            };
            _textFieldParser.ReadFields().Returns(lsoaToWardCodeRowFields)
                .AndDoes((action) => _textFieldParser.EndOfData.Returns(true));

            var actualDictionary = _lowerLayerSuperOutputAreaCodeToWardCodeParser.KeyValueParse();

            Assert.AreEqual(expectedDictionary, actualDictionary);
        }
    }
}