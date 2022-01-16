using System.Collections.Generic;
using System.Text;

namespace QwertyTranslator.Translator
{
    public abstract class QwertyTranslatorBase : IQwertyTranslator
    {
        public Dictionary<char, char> Dictionary { get; set; }

        protected string ToLang { get; set; }
        protected string FromLang { get; set; }

        public QwertyTranslatorBase() => Dictionary = new Dictionary<char, char>();

        public string Translate(string text)
        {
            var sb = new StringBuilder(text.Length);

            for (var i = 0; i < text.Length; i++)
            {
                var key = text[i];
                if (Dictionary.TryGetValue(key, out var value))
                {
                    sb.Append(value);
                }
                else
                {
                    sb.Append(key);
                }
            }

            return sb.ToString();
        }
    }

}
