using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EnvDTE;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;

namespace stereoptic
{
    internal class AudioProcessor
    {
        private WasapiLoopbackCapture capture;
        

        public AudioProcessor()
        {
            capture = new WasapiLoopbackCapture();
            capture.DataAvailable += OnDataAvailable;
            capture.RecordingStopped += OnRecordingStopped;
        }

        public void Start()
        {
            capture.StartRecording();
        }

        public void Stop()
        {
            capture.StopRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            var buffer = new float[e.BytesRecorded / 4];

            Buffer.BlockCopy(e.Buffer, 0, buffer, 0, e.BytesRecorded);

            var volumeLevels = new float[128];

            for (int i = 0; (i < buffer.Length && i < 128); i += 2)
            {
                volumeLevels[i / 2] = buffer[i]; // Left channel
                volumeLevels[i / 2 + 64] = buffer[i + 1];
            }

            for (int i = 0; i < 64; i += 4)
            {
                System.Diagnostics.Debug.Write(
                    Math.Abs(volumeLevels[i]).ToString("0.0000") + "|" + Math.Abs(volumeLevels[i + 64]).ToString("0.000") + "\t"
                    );
            }
            System.Diagnostics.Debug.Write("\r");
        }

        private void OnRecordingStopped(object sender, EventArgs e)
        {
            capture.Dispose();
        }
    }
}
