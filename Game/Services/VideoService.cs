using Raylib_cs;
using Unit06.Game.Casting;

namespace Unit06.Game.Services
{
    /// Outputs the game state.</para>
    public class VideoService
    {
        private bool debug = false;
        private Dictionary<string, Raylib_cs.Texture2D> textures
            = new Dictionary<string, Raylib_cs.Texture2D>();

        /// Constructs a new instance of KeyboardService using the given cell size.
        public VideoService(bool debug)
        {
            this.debug = debug;
        }

        /// Closes the window and releases all resources.
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// Clears the buffer in preparation for the next rendering. This method should be called at
        /// the beginning of the game's output phase.
        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.WHITE);
            if (debug) {}
        }

        /// Draws the given actor's text on the screen.
        public void DrawActor(Actor actor)
        {
            string text = actor.GetText();
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            int fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        public void DrawImage(Casting.Sprite image, Casting.Point position)
        {
            string filename = image.GetFilename();
            if (!textures.ContainsKey(filename))
            {
                Raylib_cs.Texture2D loaded = Raylib.LoadTexture(filename);
                textures[filename] = loaded;
            }
            Raylib_cs.Texture2D texture = textures[filename];
            int x = position.GetX();
            int y = position.GetY();
            Raylib.DrawTexture(texture, x, y, Raylib_cs.Color.WHITE);
        }

        /// Draws the given list of actors on the screen.
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }
        public void LoadImages(string directory)
        {
            List<string> filters = new List<string>() { "*.png", "*.gif", "*.jpg", "*.jpeg", "*.bmp" };
            List<string> filepaths = GetFilepaths(directory, filters);
            Console.WriteLine($"Directory: {directory}");
            foreach (string filepath in filepaths)
            {
                try 
                {
                    Console.WriteLine($"**** {filepath}");
                    Raylib_cs.Texture2D texture = Raylib.LoadTexture(filepath);
                    textures[filepath] = texture;
                }
                catch (AccessViolationException)
                {
                    Console.WriteLine($"**** {filepath}");
                }
            }
        }

        private List<string> GetFilepaths(string directory, List<string> filters)
        {
            List<string> results = new List<string>();
            foreach (string filter in filters)
            {
                string[] filepaths = Directory.GetFiles(directory, filter);
                results.AddRange(filepaths);
            }
            return results;
        }
        
        /// Copies the buffer contents to the screen. This method should be called at the end of
        /// the game's output phase.
        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        /// Whether or not the window is still open.
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /// Opens a new window with the provided title.
        public void OpenWindow()
        {
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        /// Converts the given color to it's Raylib equivalent.
        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetRed();
            int g = color.GetGreen();
            int b = color.GetBlue();
            int a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }

        public void DrawWall(Wall wall)
        {
            int posX = wall.GetPosX();
            int posY = wall.GetPosY();
            int width = wall.GetWidth();
            int height = wall.GetHeight();

            Casting.Color color = new Casting.Color(0, 0, 0);

            Raylib.DrawRectangle(posX, posY, width, height, ToRaylibColor(color));
        }
        public void DrawWalls(List<Actor> walls)
        {
            foreach (Wall wall in walls)
            {
                DrawWall(wall);
            }
        }
    }
}