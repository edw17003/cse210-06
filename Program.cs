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

            // load walls from .txt file and add them to the cast
            string wallsTextFile = System.IO.File.ReadAllText(Constants.wallsTextFile);
            string[] fileRows = wallsTextFile.Split("\n");
            for (int i=1; i<fileRows.Length-1; i++)
            {
                string[] oneRow = fileRows[i].Split(",");
                int posX = int.Parse(oneRow[0]);
                int posY = int.Parse(oneRow[1]);
                int width = int.Parse(oneRow[2]);
                int height = int.Parse(oneRow[3]);

                cast.AddActor("walls", new Wall(posX, posY, width, height));
            }

            // initialize audio
            audioService.Initialize();
            audioService.LoadSounds("Game/Assets/Sounds");
            audioService.LoadMusic("Game/Assets/Music");

            // create the script to be run each frame
            Script script = new Script();
            script.AddAction("output", new DrawTitle(videoService, gamepadService, audioService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}