using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAuth.Model
{
   public class Auth
    {
        public string? Key { get; set; }

        public string? Region { get; set; }

       public Auth()
        {

        }

       public Auth(string Key, string Region)
        {
            this.Region = Region;
            this.Key = Key;
        }

    }
}
