using CSAuth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAuth
{
    public class SpeechAuthService : IAuthService
    {
        private Auth auth = new Auth();

        public Auth GetCredentials() => auth;

        public void MakeCredentials(string Key, string Region)
        {
            auth.Key = Key;
            auth.Region = Region;
        }
    }
}
