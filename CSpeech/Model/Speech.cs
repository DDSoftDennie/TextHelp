
namespace CSSpeech.Model
{
    public class Speech
    {
        public string? Language { get; set; }
        public int TotalChar { get; set; }

        public string AccessToken { get; set; }


        public Speech()
        {

        }

        public Speech(int startChar)
        {
            TotalChar = startChar;
        }
        public Speech(string Language)
        {
           this.Language = Language;
        }

        public Speech(string Language, int startChar)
        {
            this.Language= Language;
            TotalChar = startChar;
        }
    }
}
