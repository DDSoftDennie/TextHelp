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
            var config = SpeechConfig.FromSubscription(Credentials.Key, Credentials.Region);

            using (SpeechSynthesizer synth = new SpeechSynthesizer(config))
            {
                await synth.SpeakTextAsync(TextBlock.Text);
            }
        }
    }
}
