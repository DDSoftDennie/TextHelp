using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.CognitiveServices.Speech;

namespace TextHelp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ReadAloudButon_Click(object sender, RoutedEventArgs e)
        {
            Credentials.Region = RegionTextBox.Text;
            Credentials.Key = KeyTexBox.Text;
            var config = SpeechConfig.FromSubscription(Credentials.Key,Credentials.Region);

            using (SpeechSynthesizer synth = new SpeechSynthesizer(config))
            {
                await synth.SpeakTextAsync(TextBlock.Text);
            }

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}
