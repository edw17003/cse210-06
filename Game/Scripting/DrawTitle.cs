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
        private string message;
        double temp = 0;
        private int mapIndex = 0;
        private string[] mapArray = new string[3]{Constants.wallsTextFile, Constants.map2, Constants.map3};

        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public DrawTitle(VideoService videoService, GamepadService gamepadService, AudioService audioService, string message)
        {
            this.videoService = videoService;
            this.gamepadService = gamepadService;
            this.audioService = audioService;
            this.message = message;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            videoService.ClearBuffer();

            string map = SetMap();
            DisplayMenu(map);

            videoService.FlushBuffer();

            bool startGame = gamepadService.IsButtonDown(0, "rmiddle");
            if (startGame)
            {
                string wallsTextFile = System.IO.File.ReadAllText(map);
                string[] fileRows = wallsTextFile.Split("\n");
                string[] s1 = fileRows[1].Split(",");
                string[] s2 = fileRows[2].Split(",");
                Sprite p1 = new Sprite("Game/Assets/Sprites/player1.png", 1, 0);
                Sprite p2 = new Sprite("Game/Assets/Sprites/player2.png", 1, 0);
                Point spawn1 = new Point(int.Parse(s1[0]), int.Parse(s1[1]));
                Point spawn2 = new Point(int.Parse(s2[0]), int.Parse(s2[1]));
                cast.AddActor("players", new Player(p1, spawn1));
                cast.AddActor("players", new Player(p2, spawn2));
                cast.AddActor("swords", new Sword());
                cast.AddActor("swords", new Sword());
                
                // load walls from selected .txt file and add them to the cast
                for (int i=3; i<fileRows.Length; i++)
                {
                    string[] oneRow = fileRows[i].Split(",");
                    int posX = int.Parse(oneRow[0]);
                    int posY = int.Parse(oneRow[1]);
                    int width = int.Parse(oneRow[2]);
                    int height = int.Parse(oneRow[3]);

                    cast.AddActor("walls", new Wall(posX, posY, width, height));
                }
                script.AddAction("input", new ControlActors(gamepadService, audioService));
                script.AddAction("update", new HandleCollisions());
                script.AddAction("update", new HandleCooldowns());
                script.AddAction("update", new MoveActors());
                script.AddAction("update", new PlayMusic(audioService));
                script.AddAction("output", new DrawActors(videoService));
                script.AddAction("endgame", new EndGame(videoService, gamepadService, audioService));
                script.RemoveAction("output", script.GetActions("output")[0]);
            }
        }

        private void DisplayMenu(string map)
        {
            int messageWidth = videoService.MeasureText(Constants.STARTMESSAGE, Constants.STARTMESSAGESIZE);

            // Draw start menu text to screen
            videoService.DrawText("Arrow keys to switch maps", 20, 10, Constants.STARTMESSAGESIZE, Constants.BLACK);
            videoService.DrawText($"<{map}>", 20, 60, Constants.STARTMESSAGESIZE, Constants.BLACK);
            videoService.DrawText(Constants.STARTMESSAGE, (Constants.MAX_X / 2) - (messageWidth / 2), 
            Constants.MAX_Y / 2, Constants.STARTMESSAGESIZE, Constants.BLACK);
        }

        private string SetMap()
        {
            // Get map selection based on d-pad
            if (gamepadService.IsButtonDown(0, "lfl") && temp > 0)
            {
                this.temp -= 0.03;
            }
            if (gamepadService.IsButtonDown(0, "lfr") && temp < 2)
            {
                this.temp += 0.03;
            }
            mapIndex = Convert.ToInt32(temp);

            return mapArray[mapIndex];
        }
    }
}