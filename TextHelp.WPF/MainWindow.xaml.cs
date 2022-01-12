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
          
            var config = SpeechConfig.FromSubscription(KeyTexBox.Text, RegionTextBox.Text);

            using (SpeechSynthesizer synth = new SpeechSynthesizer(config))
            {
                await synth.SpeakTextAsync(TextBlock.Text);
            }

        }


    }
}
