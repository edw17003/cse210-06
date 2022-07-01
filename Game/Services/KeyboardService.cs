using Raylib_cs;


namespace Unit06.Game.Services
{
    /// Detects player input.
    public class KeyboardService
    {
        private Dictionary<string, KeyboardKey> keys
                = new Dictionary<string, KeyboardKey>();

        /// Constructs a new instance of KeyboardService using the given cell size.
        public KeyboardService()
        {
            keys["w"] = KeyboardKey.KEY_W;
            keys["a"] = KeyboardKey.KEY_A;
            keys["s"] = KeyboardKey.KEY_S;
            keys["d"] = KeyboardKey.KEY_D;
            keys["i"] = KeyboardKey.KEY_I;
            keys["j"] = KeyboardKey.KEY_J;
            keys["k"] = KeyboardKey.KEY_K;
            keys["l"] = KeyboardKey.KEY_L;
        }

        /// Checks if the given key is currently down. (w, a, s, d, i, j, k, or l)
        public bool IsKeyDown(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyDown(raylibKey);
        }

        /// Checks if the given key is currently up. (w, a, s, d, i, j, k, or l)
        public bool IsKeyUp(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyUp(raylibKey);
        }

    }
}