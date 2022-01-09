using CSAuth.Model;
using System;


namespace CSAuth.Services
{
    public class TranslateAuthService : IAuthService
    {
        private Auth auth = new Auth();
        public Auth GetCredentials() => auth;
     

        public void MakeCredentials(string Key, string Region)
        {
            throw new NotImplementedException();
        }

        public void MakeCredentials(string Key, string Region, string EndPoint)
        {
            auth.Key = Key;
            auth.Region = Region;
            auth.EndPoint = EndPoint;
        }
    }
}
