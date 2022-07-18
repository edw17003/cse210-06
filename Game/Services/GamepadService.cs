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

        /// Checks if the given button is currently down.
        public bool IsButtonDown(int gamepad, string key)
        {
            GamepadButton raylibKey = buttons[key.ToLower()];
            return Raylib.IsGamepadButtonDown(gamepad, raylibKey);
        }

        /// Checks if the given button is currently up.
        public bool IsButtonUp(int gamepad, string key)
        {
            GamepadButton raylibKey = buttons[key.ToLower()];
            return Raylib.IsGamepadButtonUp(gamepad, raylibKey);
        }
        /// Returns a bool based on if a gamepad is connected
        public bool IsGamepadAvailable(int gamepad)
        {
            return Raylib.IsGamepadAvailable(gamepad);
        }
        /// Returns a vector representing the left stick
        public Vector2 GetLeftVector(int gamepad)
        {
            float x = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_X);
            float y = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_LEFT_Y);
            return new Vector2 (x, y);
        }
        /// Returns a vector representing the right stick
        public Vector2 GetRightVector(int gamepad)
        {
            float x = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_X);
            float y = Raylib.GetGamepadAxisMovement(gamepad, GamepadAxis.GAMEPAD_AXIS_RIGHT_Y);
            return new Vector2 (x, y);
        }
    }
}