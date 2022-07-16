using Raylib_cs;


namespace Unit06.Game.Services
{
    public class AudioService
    {
        private Dictionary<string, Raylib_cs.Sound> sounds 
            = new Dictionary<string, Raylib_cs.Sound>();

        private Dictionary<string, Raylib_cs.Music> music = new Dictionary<string, Raylib_cs.Music>();
        
        /// <summary>
        /// Constructs a new RaylibAudioService.
        /// </summary>
        public AudioService()
        {
        }

        /// </inheritdoc>
        public void Initialize()
        {
            Raylib.InitAudioDevice();
        }

        /// </inheritdoc>
        public void LoadSounds(string directory)
        {
            List<string> filters = new List<string>() { "*.wav", "*.mp3", "*.acc", "*.wma" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Sound sound = Raylib.LoadSound(filepath);
                sounds[filepath] = sound;
            }
        }
     public void LoadMusic(string directory)
        {
            List<string> filters = new List<string>() { "*.wav", "*.mp3", "*.acc", "*.wma" };
            List<string> filepaths = GetFilepaths(directory, filters);
            foreach (string filepath in filepaths)
            {
                Raylib_cs.Music song = Raylib.LoadMusicStream(filepath);
                music[filepath] = song;
            }
        }
 
        /// </inheritdoc>
        public void PlaySound(Casting.Sound sound)
        {
            string filename = sound.GetFilename();
            if (sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound raylibSound = sounds[filename];
                Raylib.PlaySound(raylibSound);
            }
        }
        public bool IsSoundPlaying(Casting.Sound sound)
        {
            bool IsPlaying = false;
            string filename = sound.GetFilename();
            if (sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound raylibSound = sounds[filename];
                IsPlaying = Raylib.IsSoundPlaying(raylibSound);
            }
            return IsPlaying;
        }
        public bool IsMusicPlaying(Casting.Sound sound)
        {
            bool IsPlaying = false;
            string filename = sound.GetFilename();
            if (music.ContainsKey(filename))
            {
                Raylib_cs.Music raylibMusic = music[filename];
                IsPlaying = Raylib.IsMusicStreamPlaying(raylibMusic);
            }
            return IsPlaying;
        }
        public void PlayMusic(Casting.Sound sound)
        {
            string filename = sound.GetFilename();
            if (music.ContainsKey(filename))
            {
                Raylib_cs.Music raylibMusic = music[filename];
                Raylib.PlayMusicStream(raylibMusic);
            }
        }

        public void StopMusic(Casting.Sound sound)
        {
            string filename = sound.GetFilename();
            if (music.ContainsKey(filename))
            {
                Raylib_cs.Music raylibMusic = music[filename];
                Raylib.StopMusicStream(raylibMusic);
            }
        }
        public void UpdateMusic(Casting.Sound sound)
        {
            string filename = sound.GetFilename();
            if (music.ContainsKey(filename))
            {
                Raylib_cs.Music raylibMusic = music[filename];
                Raylib.UpdateMusicStream(raylibMusic);
            }
        }

        /// </inheritdoc>
        public void Release()
        {
            Raylib.CloseAudioDevice();
        }

        /// </inheritdoc>
        public void UnloadSounds()
        {
            foreach (string filepath in sounds.Keys)
            {
                Raylib_cs.Sound raylibSound = sounds[filepath];
                Raylib.UnloadSound(raylibSound);
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            foreach (string filter in filters)
            {
                string[] filepaths = Directory.GetFiles(directory, filter);
                results.AddRange(filepaths);
            }
            return results;
        }
    }
}