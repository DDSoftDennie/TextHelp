using CSAuth.Model;

namespace CSTranslator.Services
{
    public interface ITranslatorService
    {
        public string Authenticate(Auth authentication);
        public Task<string> Translate(string text);
    }
}
