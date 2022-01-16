namespace QwertyTranslator.Translator
{
    public class RusToEngQwertyTranslator : QwertyTranslatorBase
    {
        public RusToEngQwertyTranslator()
        {
            FromLang = "ё1234567890-=йцукенгшщзхъфывапролджэячсмитьбю. \n\tЁ!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,";
            ToLang = "`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./ \n\t~!@#$%^&*()_+}{POIUYTREWQASDFGHJKL:\"?><MNBVCXZ";

            for (var i = 0; i < FromLang.Length; i++)
            {
                var key = FromLang[i];
                var value = ToLang[i];
                Dictionary[key] = value;
            }
        }

        public override string ToString() => "ru-eng";
    }
}
