using CSAuth.Model;


namespace CSAuth.Services
{
    public interface IAuthService
    {
       void MakeCredentials(string Key, string Region);
       void MakeCredentials(string Key, string Region, string EndPoint);

       Auth GetCredentials();

    }
}
