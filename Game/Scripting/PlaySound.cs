using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class PlaySound : Action
    {
        private AudioService audioService;
        private string filename;

        public PlaySound(AudioService audioService, string filename)
        {
            this.audioService = audioService;
            this.filename = filename;
        }

        public void Execute(Cast cast, Script script)
        {
            Sound sound = new Sound(filename);
            audioService.PlaySound(sound);
        }
    }
}