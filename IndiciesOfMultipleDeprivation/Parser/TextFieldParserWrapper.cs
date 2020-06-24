using Microsoft.VisualBasic.FileIO;

namespace IndiciesOfMultipleDeprivation.Parser
{
    public class TextFieldParserWrapper : ITextFieldParser
    {
        private readonly TextFieldParser _textFieldParser;

        public TextFieldParserWrapper(TextFieldParser textFieldParser)
        {
            _textFieldParser = textFieldParser;
        }

        public string[] CommentTokens
        {
            set => _textFieldParser.CommentTokens = value;
        }

        public bool HasFieldsEnclosedInQuotes
        {
            set => _textFieldParser.HasFieldsEnclosedInQuotes = value;
        }
        
        public void SetDelimiters(params string[] delimiters)
        {
            _textFieldParser.SetDelimiters(delimiters);
        }

        public bool EndOfData
        {
            get => _textFieldParser.EndOfData;
        }

        public string ReadLine()
        {
            return _textFieldParser.ReadLine();
        }

        public string[] ReadFields()
        {
            return _textFieldParser.ReadFields();
        }
    }
}