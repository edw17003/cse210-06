namespace Unit06.Game.Casting
{
    /// A sound.
    public class Sound
    {
        private string filename;
        private int volume;
        private bool repeated;
        
        /// Constructs a new instance of Sound.
        public Sound(string filename, int volume = 1, bool repeated = false)
        {
            this.filename = filename;
            this.volume = volume;
            this.repeated = repeated;
        }

        /// Gets the filename.
        public string GetFilename()
        {
            return filename;
        }

        /// Gets the volume.
        public int GetVolume()
        {
            return volume;
        }

        /// Whether or not the sound should be repeated.
        public bool IsRepeated()
        {
            return repeated;
        }
        
    }
}