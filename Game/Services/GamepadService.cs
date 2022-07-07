using Raylib_cs;
using System.Numerics;

namespace Unit06.Game.Services
{
    public class GamepadService
    {
        private Dictionary<string, GamepadButton>buttons
                = new Dictionary<string, GamepadButton>();

        /// Constructs a new instance of KeyboardService using the given cell size.
        public GamepadService()
        {
           buttons["lfd"] = GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_DOWN;
           buttons["lfl"] = GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT;
           buttons["lfr"] = GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_RIGHT;
           buttons["lfu"] = GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_UP;
           buttons["lsb"] = GamepadButton.GAMEPAD_BUTTON_LEFT_THUMB;
           buttons["rsb"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_THUMB;
           buttons["lb"] = GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_1;
           buttons["lt"] = GamepadButton.GAMEPAD_BUTTON_LEFT_TRIGGER_2;
           buttons["rb"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_1;
           buttons["rt"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_TRIGGER_2;
           buttons["middle"] = GamepadButton.GAMEPAD_BUTTON_MIDDLE;
           buttons["lmiddle"] = GamepadButton.GAMEPAD_BUTTON_MIDDLE_LEFT;
           buttons["rmiddle"] = GamepadButton.GAMEPAD_BUTTON_MIDDLE_RIGHT;
           buttons["rfd"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN;
           buttons["rfl"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_LEFT;
           buttons["rfr"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_RIGHT;
           buttons["rfu"] = GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_UP;
           buttons["unknown"] = GamepadButton.GAMEPAD_BUTTON_UNKNOWN;
        }

        /// Checks if the given key is currently down. (w, a, s, d, i, j, k, or l)
        public bool IsButtonDown(int gamepad, string key)
        {
            GamepadButton raylibKey = buttons[key.ToLower()];
            return Raylib.IsGamepadButtonDown(gamepad, raylibKey);
        }

        /// Checks if the given key is currently up. (w, a, s, d, i, j, k, or l)
        public bool IsButtonUp(int gamepad, string key)
        {
            GamepadButton raylibKey = buttons[key.ToLower()];
            return Raylib.IsGamepadButtonUp(gamepad, raylibKey);
        }

        public bool IsGamepadAvailable(int gamepad)
        {
            return Raylib.IsGamepadAvailable(gamepad);
        }

        public Vector2 GetLeftVector(int gamepad)
        {
            float x = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_X);
            float y = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_Y);
            return new Vector2 (x, y);
        }

        public Vector2 GetRightVector(int gamepad)
        {
            float x = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_X);
            float y = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y);
            return new Vector2 (x, y);
        }
    }
}






/* // Input-related functions: gamepads
    bool IsGamepadAvailable(int gamepad);                                   // Check if a gamepad is available
    const char *GetGamepadName(int gamepad);                                // Get gamepad internal name id
    bool IsGamepadButtonPressed(int gamepad, int button);                   // Check if a gamepad button has been pressed once
    bool IsGamepadButtonDown(int gamepad, int button);                      // Check if a gamepad button is being pressed
    bool IsGamepadButtonReleased(int gamepad, int button);                  // Check if a gamepad button has been released once
    bool IsGamepadButtonUp(int gamepad, int button);                        // Check if a gamepad button is NOT being pressed
    int GetGamepadButtonPressed(void);                                      // Get the last gamepad button pressed
    int GetGamepadAxisCount(int gamepad);                                   // Get gamepad axis count for a gamepad
    float GetGamepadAxisMovement(int gamepad, int axis);                    // Get axis movement value for a gamepad axis
    int SetGamepadMappings(const char *mappings);                           // Set internal gamepad mappings (SDL_GameControllerDB) */