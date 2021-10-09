using CSAuth.Model;
using CSSpeech.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSpeech
{
   public interface ISpeechService
    {
        public string Authenticate(Auth authentication);

        public string Configure(Speech speech);

        public Task ReadAloud(string text);
    }
}
