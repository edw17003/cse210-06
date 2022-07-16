using Unit06.Game.Casting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting 
{
    /// The responsibility of action is to do something that is integral or important in the game. 
    /// Thus, it has one method, Execute(...), which should be overridden by derived classes.
    public class StartTimer : Action
    {
        private VideoService videoService;
        private GamepadService gamepadService;
        private AudioService audioService;
        private int timerTemp = 0;
        private string seconds = "3";
        public StartTimer(VideoService videoService, GamepadService gamepadService, AudioService audioService)
        {
            this.videoService = videoService;
            this.gamepadService = gamepadService;
            this.audioService = audioService;
        }
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        public void Execute(Cast cast, Script script)
        {
            Actor actor = cast.GetFirstOfKey("messages");
            
            
            actor.SetText(seconds);
            cast.AddActor("messages", actor);
            Start(script, cast, actor);
        }
        private void Start(Script script, Cast cast, Actor actor)
        {
            // Set seconds based on framerate
            this.timerTemp++;
            seconds = "3";

            if (this.timerTemp < Constants.FRAME_RATE)
            {
                this.seconds = "3";
            }
            else if (this.timerTemp < (Constants.FRAME_RATE * 2))
            {
                this.seconds = "2";
            }
            else if (this.timerTemp < (Constants.FRAME_RATE * 3))
            {
                this.seconds = "1";
            }
            else
            {
                script.AddAction("input", new ControlActors(gamepadService, audioService));
                script.AddAction("update", new HandleCollisions());
                script.AddAction("update", new HandleCooldowns());
                script.AddAction("update", new MoveActors());
                script.AddAction("update", new SpawnPowerup());
                cast.RemoveActor("messages", actor);
                script.RemoveAction("timer", script.GetActions("timer")[0]);
                this.seconds = "";
            }
            
            
            
        }
    }
}