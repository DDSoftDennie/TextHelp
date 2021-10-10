using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAuth;
using CSSpeech;
using CSAuth.Model;
using CSSpeech.Model;
using System.Windows;

namespace TextHelp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SpeechAuthService _speechAuthService = new SpeechAuthService();
        private SpeechService _speechService = new SpeechService();
        private Auth _auth = new Auth();
        private Speech _speech = new Speech();


        public MainWindow()
        {
            InitializeComponent();
        }

   

        public async Task ReadAloud(string text)
        {
            await _speechService.ReadAloud(text);
            return;
        }

        private void Connect()
        {
            _speechAuthService.MakeCredentials(KeyTexBox.Text, RegionTextBox.Text);
            _auth = _speechAuthService.GetCredentials();
            _speechService.Authenticate(_auth);
            _speech = new Speech
            {
                Language = LanguageTextBox.Text
            };
            _speechService.Configure(_speech);
        }

        private async void ReadAloudButon_Click(object sender, RoutedEventArgs e)
        {
            Connect();
            await ReadAloud(TextBlock.Text);

        }
    }
}
