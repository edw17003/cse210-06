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
                script.AddAction("input", new ControlActors(gamepadService));
                script.AddAction("update", new HandleCollisions(audioService));
                script.AddAction("update", new HandleCooldowns());
                script.AddAction("update", new MoveActors());
                script.AddAction("update", new PlayMusic(audioService));
                script.AddAction("output", new DrawActors(videoService));
                script.AddAction("endgame", new EndGame(videoService, gamepadService, audioService));
                script.RemoveAction("output", script.GetActions("output")[0]);
            }
            videoService.ClearBuffer();
            videoService.DrawText(Constants.STARTMESSAGE, (Constants.MAX_X / 2) - (messageWidth / 2), 
            Constants.MAX_Y / 2, Constants.STARTMESSAGESIZE, Constants.BLACK);
            videoService.FlushBuffer();
        }
    }
}