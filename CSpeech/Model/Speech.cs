
namespace CSSpeech.Model
{
    public class Speech
    {
        public string? Language { get; set; }

        public Speech()
        {

        }

        public Speech(string Language)
        {
            this.Language = Language;
        }
    }
}
