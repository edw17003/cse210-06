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
            cast.AddActor("swords", new Sword());
            cast.AddActor("swords", new Sword());
            // Top Border (x, y, height, width) 1600 x 900
            cast.AddActor("walls", new Wall(0, 0, 20, 1600));
            // Left Border
            cast.AddActor("walls", new Wall(0, 0, 900, 20));
            // Bottom Border
            cast.AddActor("walls", new Wall(0, 880, 20, 1600));
            // Right Border
            cast.AddActor("walls", new Wall(1580, 0, 900, 20));

            // Left-vertical barrier
            cast.AddActor("walls", new Wall(300, 175, 550, 20));
            // Right-vertical barrier
            cast.AddActor("walls", new Wall(1300, 175, 550, 20));
            // Left-horizontal barrier
            cast.AddActor("walls", new Wall(220, 725, 20, 600));
            // Right-horizontal barrier
            cast.AddActor("walls", new Wall(800, 175, 20, 600));

            // Left-vertical nub
            cast.AddActor("walls", new Wall(220, 250, 20, 80));
            // right-vertical nub
            cast.AddActor("walls", new Wall(1320, 625, 20, 80));
            // Left-horizontal nub
            cast.AddActor("walls", new Wall(740, 725, 80, 20));
            // Right-horizontal nub
            cast.AddActor("walls", new Wall(880, 115, 80, 20));

            //Sound sound = new Sound("laser.wav", 1, true);
            
            
            // create the script

            Script script = new Script();
            script.AddAction("input", new ControlActors(gamepadService));
            script.AddAction("update", new MoveActors());
            script.AddAction("update", new HandleCollisions());
            script.AddAction("output", new DrawActors(videoService));
            //script.AddAction("sound", new PlaySound(audioService, sound));
            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}