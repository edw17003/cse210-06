using Unit06.Game.Casting;
using Unit06.Game.Directing;
using Unit06.Game.Scripting;
using Unit06.Game.Services;
using Unit06.Game;


namespace Unit06
{
    /// The program's entry point.
    class Program
    {
        /// Starts the program using the given arguments.
        static void Main(string[] args)
        {
            // create the services
            // KeyboardService keyboardService = new KeyboardService();
            GamepadService gamepadService = new GamepadService();
            VideoService videoService = new VideoService(false);
            AudioService audioService = new AudioService();

            // create the cast
            Cast cast = new Cast();
            
            // initialize audio
            audioService.Initialize();
            audioService.LoadSounds("Game/Assets/Sounds");
            audioService.LoadMusic("Game/Assets/Music");

            // create the script to be run each frame
            Script script = new Script();
            script.AddAction("output", new DrawTitle(videoService, gamepadService, audioService, Constants.STARTMESSAGE));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}