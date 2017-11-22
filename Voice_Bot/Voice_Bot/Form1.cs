using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Voice_Bot
{

    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;
        Choices list = new Choices();
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new String[] { "hello", "how are you", "what time is it", "What is fuck","What are you doing", "I am just developing more data for you sarah","what day is it","open","wake","sleep"});
            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized +=rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch{ return; }

            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("Hello, I am Sarah");
            s.Speak("Welcome Master");
            InitializeComponent();
        }

        public void say(string h)
        {
            s.Speak(h);
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string r = e.Result.Text;

            if (r == "wake") wake = true;
            if (r == "sleep") wake = false;
            

            if (wake == true)
            {
                //what you say
                if (r == "hello")
                {
                    say("Hi");//what bot reply
                }
                if (r == "what time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }
                if (r == "what day is it")
                {
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }
                if (r == "how are you")
                {
                    say("Great, and you");
                }
                if (r == "What is fuck")
                {
                    say("fuck is a bad word, please master don't use such word");
                }
                if (r == "What are you doing")
                {
                    say("just developing myself master. what about you master");
                }
                if (r == "I am just developing more data for you sarah")
                {
                    say("thanks sir! you're seems being faster than 0 and 1");
                }
                if (r == "open")
                {
                    Process.Start("http://www.google.com");
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {       

        }
    }
}
