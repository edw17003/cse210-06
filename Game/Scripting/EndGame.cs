using Unit06.Game.Casting;
using Unit06.Game.Services;
using Raylib_cs;


namespace Unit06.Game.Scripting
{
    /// The responsibility of DrawActorsAction is to draw each of the actors.</para>
    public class EndGame : Action
    {
        private VideoService videoService;
        private GamepadService gamepadService;
        private AudioService audioService;

        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public EndGame(VideoService videoService, GamepadService gamepadService, AudioService audioService)
        {
            this.videoService = videoService;
            this.gamepadService = gamepadService;
            this.audioService = audioService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            List<Actor> players = cast.GetActors("players");
            foreach (Player player in players)
            {
                if (player.GetHealth() <= 0)
                {
                    audioService.StopMusic(new Casting.Sound("Game/Assets/Music\\music.mp3"));
                    string winner = player.GetPlayerColor();
                    
                    script.RemoveAllOfKey("update");
                    script.RemoveAllOfKey("input");
                    script.RemoveAllOfKey("sound");
                    script.RemoveAction("output", script.GetActions("output")[0]);
                    script.RemoveAction("endgame", script.GetActions("endgame")[0]);
                    script.AddAction("output", new DrawTitle(videoService, gamepadService, audioService, $"{winner} loses! Press Start to Play Again."));
                    cast.RemoveAllActors();
                    break;
                }
            }
        }
    }
}



