
namespace CSTranslator.Model
{
    public class Translator
    {
        public string? LanguageFrom { get; set; }

        public string?  LanguageTo { get; set; }

        public Translator()
        {

        }

        public Translator(string LanguageFrom, string LanguageTo)
        {
            this.LanguageFrom = LanguageFrom;
            this.LanguageTo = LanguageTo;
        }
    }
}
