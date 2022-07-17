using Unit06.Game.Casting;

namespace Unit06.Game
{
    /// Constants used throughout the project
    public class Constants
    {
        public static int max_overheal = 50;
        public static string laserSound = "Game/Assets/Sounds\\laser.wav";
        public static string map1 = "Game/Assets/MapData/map.txt";
        public static string map2 = "Game/Assets/MapData/map2.txt";
        public static string map3 = "Game/Assets/MapData/map3.txt";
        public static string map4 = "Game/Assets/MapData/map4.txt";
        public static string player1Sprite = "Game/Assets/Sprites/player1.png";
        public static string player2Sprite = "Game/Assets/Sprites/player2.png";
        public static string throwSound = "Game/Assets/Sounds\\laser.wav";
        public static string mapFile = "Game/Assets/MapData/map.txt";
        public static string backgroundPath = "Game/Assets/Sprites/background.png";
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 1600;
        public static int MAX_Y = 900;

        public static int FRAME_RATE = 240;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Fight!";
        public static string STARTMESSAGE = "Press the Start button to begin";
        public static int STARTMESSAGESIZE = 40;
        public static int TIMERSIZE = 70;

        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color BLACK = new Color(0, 0, 0);
    }
}

