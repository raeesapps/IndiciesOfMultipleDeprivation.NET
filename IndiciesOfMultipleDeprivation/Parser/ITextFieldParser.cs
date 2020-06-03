namespace IndiciesOfMultipleDeprivation.Parser
{
    public interface ITextFieldParser
    {
        public string[] CommentTokens { set; }
        public bool HasFieldsEnclosedInQuotes { set; }
        public void SetDelimiters(params string[] delimiters);
        public bool EndOfData { get; }
        public string ReadLine();
        public string[] ReadFields();
    }
}