namespace QwertyTranslator.Translator
{
    public class QwertyTranslatorMediator
    {
        private IQwertyTranslator OneWay { get; set; }
        private IQwertyTranslator OtherWay { get; set; } 

        public QwertyTranslatorMediator(IQwertyTranslator oneWay, IQwertyTranslator otherWay)
        {
            OneWay = oneWay;
            OtherWay = otherWay;
        }

        public string Translate(string text, Language languange)
        {
            return languange == Language.English 
                 ? OtherWay.Translate(text) 
                 : OneWay.Translate(text);
        }
    }
}
