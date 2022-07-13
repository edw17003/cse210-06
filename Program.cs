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

            audioService.Initialize();
            audioService.LoadSounds("Game/Assets/Sounds");
            audioService.LoadMusic("Game/Assets/Music");

            // Top Border (x, y, height, width) 1600 x 900
            cast.AddActor("walls", new Wall(0, 0, 1600, 20));
            // Left Border
            cast.AddActor("walls", new Wall(0, 0, 20, 900));
            // Bottom Border
            cast.AddActor("walls", new Wall(0, 880, 1600, 20));
            // Right Border
            cast.AddActor("walls", new Wall(1580, 0, 20, 900));

            // Left-vertical barrier
            cast.AddActor("walls", new Wall(300, 175, 20, 550));
            // Right-vertical barrier
            cast.AddActor("walls", new Wall(1300, 175, 20, 550));
            // Left-horizontal barrier
            cast.AddActor("walls", new Wall(220, 725, 600, 20));
            // Right-horizontal barrier
            cast.AddActor("walls", new Wall(800, 175, 600, 20));

            // Left-vertical nub
            cast.AddActor("walls", new Wall(220, 250, 80, 20));
            // right-vertical nub
            cast.AddActor("walls", new Wall(1320, 625, 80, 20));
            // Left-horizontal nub
            cast.AddActor("walls", new Wall(740, 725, 20, 80));
            // Right-horizontal nub
            cast.AddActor("walls", new Wall(880, 115, 20, 80));
            
            //Sound sound = new Sound("laser.wav", 1, true);
            
            
            // create the script

            Script script = new Script();
            script.AddAction("input", new ControlActors(gamepadService));
            script.AddAction("update", new HandleCollisions(audioService));
            script.AddAction("update", new HandleCooldowns());
            script.AddAction("update", new MoveActors());
            script.AddAction("update", new PlayMusic(audioService));
            script.AddAction("output", new DrawActors(videoService));
            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
            
        }
    }
}