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

            string mapFile = System.IO.File.ReadAllText(Constants.mapFile);
            string[] fileRows = mapFile.Split("\n");

            string[] p1Row = fileRows[1].Split(",");
            string[] p2Row = fileRows[2].Split(",");

            Point spawn1 = new Point(int.Parse(p1Row[0]), int.Parse(p1Row[1]));
            Point spawn2 = new Point(int.Parse(p2Row[0]), int.Parse(p2Row[1]));
            
            Sprite p1 = new Sprite(Constants.player1Sprite, 1, 0);
            Sprite p2 = new Sprite(Constants.player2Sprite, 1, 0);

            cast.AddActor("players", new Player(p1, spawn1));
            cast.AddActor("players", new Player(p2, spawn2));
            cast.AddActor("swords", new Sword());
            cast.AddActor("swords", new Sword());

            for (int i=3; i<fileRows.Length-3; i++)
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