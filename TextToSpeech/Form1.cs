using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer ss;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ss = new SpeechSynthesizer();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ss.Rate = trackBarSpeed.Value;
            ss.Volume = trackBarVolume.Value;
            ss.SpeakAsync(txtMessage.Text);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            ss.Pause();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ss.Resume();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Rate = trackBarSpeed.Value;
            ss.Volume = trackBarVolume.Value;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Wav Files| *.wav";
            sfd.ShowDialog();
            ss.SetOutputToWaveFile(sfd.FileName);
            ss.Speak(txtMessage.Text);
            ss.SetOutputToDefaultAudioDevice();
            MessageBox.Show("Recording Completed", "Information");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
