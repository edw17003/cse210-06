using Unit06.Game.Casting;
using Unit06.Game.Services;
using Raylib_cs;


namespace Unit06.Game.Scripting
{
    /// The responsibility of DrawTitleAction is to draw each of the actors.</para>
    public class DrawTitle : Action
    {
        private VideoService videoService;
        private GamepadService gamepadService;
        private AudioService audioService;

        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public DrawTitle(VideoService videoService, GamepadService gamepadService, AudioService audioService)
        {
            this.videoService = videoService;
            this.gamepadService = gamepadService;
            this.audioService = audioService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            int messageWidth = videoService.MeasureText(Constants.STARTMESSAGE, Constants.STARTMESSAGESIZE);

            bool startGame = gamepadService.IsButtonDown(0, "rmiddle");
            if (startGame)
            {
                script.AddAction("input", new ControlActors(gamepadService));
                script.AddAction("update", new HandleCollisions(audioService));
                script.AddAction("update", new HandleCooldowns());
                script.AddAction("update", new MoveActors());
                script.AddAction("update", new PlayMusic(audioService));
                script.AddAction("output", new DrawActors(videoService));
                script.RemoveAction("output", script.GetActions("output")[0]);
            }
            videoService.ClearBuffer();
            videoService.DrawText(Constants.STARTMESSAGE, (Constants.MAX_X / 2) - (messageWidth / 2), 
            Constants.MAX_Y / 2, Constants.STARTMESSAGESIZE, Constants.BLACK);
            videoService.FlushBuffer();
        }
    }
}