// See https://aka.ms/new-console-template for more information
using Cons.Controllers;
using System;
using CSTranslator;
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;


//DisplayController display = new DisplayController();
//SpeechController speech = new SpeechController();

//display.DisplayHeader();
//display.DrawLine(20);
//(string, string) credentials = ((string, string))display.AskCredentials();
//display.DisplayText(speech.Authenticate(credentials));
//display.DrawLine(25);
//string lang = display.AskLanguage(); ;
//display.DisplayText(speech.SetLanguage(lang));
//display.DrawLine(150);

//bool mayContinue;
//do
//{
//    string input = display.AskInput("Type a text you want to read aloud...");
//    display.DisplayText(await speech.ReadAloud(input));
//    display.DrawLine(25);
//    mayContinue = display.AskToContinue();
//} while (mayContinue);

//display.DisplayFooter();
//Console.ReadKey();

Console.WriteLine("Please give your Key");
string k = Console.ReadLine();
Console.WriteLine("Please give your endpoint");
string ep = Console.ReadLine();
Console.WriteLine("Please enter your region: ");
string r = Console.ReadLine();
Console.WriteLine("Please enter text to translate: NL");
string txt = Console.ReadLine();

string translated = await CSTranslator.Translator.Translate(k, ep, txt, r);
Console.WriteLine(translated);


//TODO: REFACTOR:
/* 1: 
 * 2: Navigation Menu
 * 3: Work for Translate with CSAuth
 * 3.1: Remove usings & Nuget from Cons
 * 4: Implement Translate & Speech 
 * 5: Implement in WPF
 * 6: Work all warnings away
 * 7: NOT SURE: Consistancy: REST way for CSSPeech
 *      *If: make Interface for speech to speech
 * */

async void SpeechMethod()
{
    
}

