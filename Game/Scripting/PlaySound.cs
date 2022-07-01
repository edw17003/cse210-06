using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class PlaySound : Action
    {
        private AudioService audioService;

        private Sound sound;

        public PlaySound(AudioService audioService, Sound sound)
        {
            this.audioService = audioService;
            this.sound = sound;
        }

        public void Execute(Cast cast, Script script)
        {
            audioService.PlaySound(sound);
        }
    }
}