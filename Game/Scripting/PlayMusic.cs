using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class PlayMusic : Action
    {
        private AudioService audioService;

        private Sound music;

        public PlayMusic(AudioService audioService)
        {
            this.audioService = audioService;
            music = new Sound("Game/Assets/Music\\music.mp3");
        }

        public void Execute(Cast cast, Script script)
        {
            // if music is not playing, play music. Else, update music stream
            if (!audioService.IsMusicPlaying(music))
            {
                audioService.PlayMusic(music);
            }
            audioService.UpdateMusic(music);
        }
    }
}