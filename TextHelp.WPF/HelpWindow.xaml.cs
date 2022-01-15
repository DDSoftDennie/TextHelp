using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TextHelp.WPF
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private async void readAloudButton_Click(object sender, RoutedEventArgs e)
        {
            string[] text = new string[5];
            text[0] = "How do I use this app?";
            text[1] = "You can use this app to write text and listen to the text.";
            text[2] = "You can use this app together with someone with a learning disability,";
            text[3] = "if you do this, the caregiver can write text and let it read aload to the person with special needs.";
            text[4] = "You can paste text in this app and let this read aloud.";
            var config = SpeechConfig.FromSubscription(Credentials.Key, Credentials.Region);

            SpeechSynthesizer synth = new SpeechSynthesizer(config);
            foreach (string s in text)
            {
                await synth.SpeakTextAsync(s);
            }
        }
    }
}
