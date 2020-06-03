using System.Collections.Generic;

namespace IndiciesOfMultipleDeprivation.Parser
{
    public abstract class CsvParser<K, V> : ILinearParser<K>, IKeyValueParser<K, V>
    {
        private readonly ITextFieldParser _textFieldParser;

        public CsvParser(ITextFieldParser textFieldParser)
        {
            _textFieldParser = textFieldParser;
        }

        private void ReadCsvPath(IList<K> list, IDictionary<K, V> dictionary)
        {
            _textFieldParser.CommentTokens = new string[] { "#" };
            _textFieldParser.SetDelimiters(new string[] { "," });
            _textFieldParser.HasFieldsEnclosedInQuotes = true;

            _textFieldParser.ReadLine();

            while (!_textFieldParser.EndOfData)
            {
                var fields = _textFieldParser.ReadFields();

                if (list == null && dictionary != null)
                {
                    OnReadFields(dictionary, fields);
                } 
                else if (dictionary == null && list != null)
                {
                    OnReadFields(list, fields);
                }
            }
        }
        
        public IList<K> Parse()
        {
            var ks = new List<K>();
            ReadCsvPath(ks, null);
            return ks;
        }

        public IDictionary<K, V> KeyValueParse()
        {
            var kvs = new Dictionary<K, V>();
            ReadCsvPath(null, kvs);
            return kvs;
        }

        protected abstract void OnReadFields(IList<K> ks, string[] fields);
        protected abstract void OnReadFields(IDictionary<K, V> kvs, string[] fields);
    }
}