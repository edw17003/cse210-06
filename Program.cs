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
            KeyboardService keyboardService = new KeyboardService();
            GamepadService gamepadService = new GamepadService();
            VideoService videoService = new VideoService(false);
            AudioService audioService = new AudioService();
            // videoService.LoadImages("Game/Assets/Sprites");
            // create the cast
            Cast cast = new Cast();
            Sprite p1 = new Sprite("Game/Assets/Sprites/player1.png", 1, 0);
            Sprite p2 = new Sprite("Game/Assets/Sprites/player2.png", 1, 0);
            Point spawn1 = new Point(Constants.MAX_X / 3, Constants.MAX_Y / 2);
            Point spawn2 = new Point(Constants.MAX_X / 3 * 2, Constants.MAX_Y / 2);
            cast.AddActor("players", new Player(p1, spawn1));
            cast.AddActor("players", new Player(p2, spawn2));
            //Sound sound = new Sound("laser.wav", 1, true);
            
            
            // create the script

            Script script = new Script();
            script.AddAction("input", new ControlActors(gamepadService));
            script.AddAction("update", new MoveActors());
            script.AddAction("update", new HandleCollisions());
            script.AddAction("output", new DrawActors(videoService));
            //script.AddAction("sound", new PlaySound(audioService, sound));
            //script.AddAction("debug", new CheckGamepad());
            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}