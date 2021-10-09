using CSAuth.Model;


namespace CSAuth
{
    public interface IAuthService
    {
       void MakeCredentials(string Key, string Region);

       Auth GetCredentials();

    }
}
