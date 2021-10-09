using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
