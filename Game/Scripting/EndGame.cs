using Unit06.Game.Casting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting
{
    /// The responsibility of EndGame is to handle when the game ends
    public class EndGame : Action
    {
        private VideoService videoService;
        private GamepadService gamepadService;
        private AudioService audioService;

        /// Constructs a new instance of EndGame
        public EndGame(VideoService videoService, GamepadService gamepadService, AudioService audioService)
        {
            this.videoService = videoService;
            this.gamepadService = gamepadService;
            this.audioService = audioService;
        }

        /// Execute the end of the game
        public void Execute(Cast cast, Script script)
        {
            //Get the player actors
            List<Actor> players = cast.GetActors("players");
            foreach (Player player in players)
            {
                if (player.GetHealth() <= 0)
                {
                    //If a player reaches 0 health, stop the music, remove the actions, and then add the
                    //title screen action with an end game message.
                    audioService.StopMusic(new Casting.Sound("Game/Assets/Music\\music.mp3"));
                    string winner = player.GetPlayerColor(); //Is actually the loser but we think saying winner is funny
                    
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