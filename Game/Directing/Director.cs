using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    /// The responsibility of a Director is to control the sequence of play.
    public class Director
    {
        private VideoService videoService = null;

        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// Starts the game by running the main game loop for the given cast and script.
        public void StartGame(Cast cast, Script script)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                ExecuteActions("input", cast, script);
                ExecuteActions("update", cast, script);
                ExecuteActions("output", cast, script);
                ExecuteActions("sound", cast, script);
            }
            videoService.CloseWindow();
        }

        /// Executes each action in the given group.
        private void ExecuteActions(string group, Cast cast, Script script)
        {
            List<Game.Scripting.Action> actions = script.GetActions(group);
            foreach(Game.Scripting.Action action in actions)
            {
                action.Execute(cast, script);
            }
        }
    }
}