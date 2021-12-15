using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    public class AudioStream
    {
        private List<AudioFiles> _audioFiles;
        private Audio _audio = null;

        public AudioStream()
        {
        }

        public void AddNewAudio(string tag, string path)
        {
            _audioFiles.Add(new AudioFiles(tag, $"{Application.StartupPath}{path}/{tag}.png"));
        }

        public void PlaySound(string tag)
        {
            _audio = null;
            var file = _audioFiles.FirstOrDefault(x => x.Tag == tag);
            if (file == null)
            {
                throw new FileNotFoundException($"No {tag} audio found");
            }
            _audio.Play(file.Path);
        }

        public void StopSound()
        {
            _audio.Stop();
        }
    }

    public class AudioFiles
    {
        public string Tag { get; set; }
        public string Path { get; set; }

        public AudioFiles(string tag, string path)
        {
            Tag = tag;
            Path = path;
        }
    }
}
