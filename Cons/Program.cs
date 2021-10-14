// See https://aka.ms/new-console-template for more information
using Cons.Controllers;
using System;

DisplayController display = new DisplayController();
SpeechController speech = new SpeechController();

display.DisplayHeader();
display.DrawLine(20);
(string, string) credentials = ((string, string))display.AskCredentials();
display.DisplayText(speech.Authenticate(credentials));
display.DrawLine(25);
string lang = display.AskLanguage();;
display.DisplayText(speech.SetLanguage(lang));
display.DrawLine(150);

bool mayContinue;
do
{
    string input = display.AskInput("Type a text you want to read aloud...");
    display.DisplayText(await speech.ReadAloud(input));
    display.DrawLine(25);
    mayContinue = display.AskToContinue();
} while (mayContinue);

display.DisplayFooter();
Console.ReadKey();

