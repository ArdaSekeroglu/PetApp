using System;
using System.IO;
using NAudio.Wave;

namespace PetApp
{
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
        }
        public override WaveFormat WaveFormat => sourceStream.WaveFormat;
        public override long Length => sourceStream.Length;
        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = sourceStream.Read(buffer, offset, count);
            if (read == 0)
            {
                sourceStream.Position = 0;
                read = sourceStream.Read(buffer, offset, count);
            }
            return read;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sourceStream.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public static class MusicPlayer
    {
        private static WaveOutEvent? outputDevice;
        private static AudioFileReader? audioFile;
        private static float _volume = 0.2f;
        public static int CurrentVolume { get; private set; } = 20;
        public static bool IsInitialized => outputDevice != null;

        public static void Start()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.GetFullPath(Path.Combine(baseDir, "..", "..", ".."));
            string path = Path.Combine(projectRoot, "Resources", "Musics", "arkadasimPet.wav");

            Start(path);
        }

        public static void Start(string path)
        {
            Stop();

            var reader = new AudioFileReader(path)
            {
                Volume = _volume
            };

            audioFile = reader;

            var loop = new LoopStream(reader);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(loop);
            outputDevice.Play();
        }

        public static void Stop()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            outputDevice = null;

            audioFile?.Dispose();
            audioFile = null;
        }

        public static void SetVolume(int level)
        {
            if (level < 0) level = 0;
            if (level > 100) level = 100;
            _volume = level / 100f;
            CurrentVolume = level;
            if (audioFile != null)
                audioFile.Volume = _volume;
            Properties.Settings.Default.SavedVolume = level;
            Properties.Settings.Default.Save();
        }
    }
}
