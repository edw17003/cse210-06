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
            // create the cast
            Cast cast = new Cast();
            Color color1 = new Color(255, 0, 0);
            Color color2 = new Color(0, 255, 0);
            Point spawn1 = new Point(Constants.MAX_X / 3, Constants.MAX_Y / 2);
            Point spawn2 = new Point(Constants.MAX_X / 3 * 2, Constants.MAX_Y / 2);
            cast.AddActor("player1", new Player(color1, spawn1));
            cast.AddActor("player2", new Player(color2, spawn2));
            Sound sound = new Sound("laser.wav", 1, true);
            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
            AudioService audioService = new AudioService();
            // create the script

            Script script = new Script();
            script.AddAction("input", new ControlActors(keyboardService));
            script.AddAction("update", new MoveActors());
            script.AddAction("update", new HandleCollisions());
            script.AddAction("output", new DrawActors(videoService));
<<<<<<< HEAD
            script.AddAction("sound", new PlaySound(audioService, "laser.wav"));
            script.AddAction("debug", new CheckGamepad());
=======
            script.AddAction("sound", new PlaySound(audioService, sound));
            script.AddAction("debug", new CheckGamepad()); // <------------ This is what writes to the console so often
>>>>>>> 98ddfaa57b1d5f1bb786fad25c31cb7d59c0d22d
            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}