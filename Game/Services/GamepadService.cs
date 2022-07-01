using Raylib_cs;

namespace Unit06.Game.Services
{
    public class GamepadService
    {
        public GamepadService()
        {
        }
    
        public char GetGamepadName(int gamepad)
        {
            return Raylib.GetGamepadName(gamepad);
        }

        public bool IsGamepadButtonDown(int gamepad, int button)
        {
            return Raylib.IsGamepadButtonDown(gamepad, button);
        }

        public float GetGamepadAxisMovement(int gamepad, string axis)
        {
            Raylib.GetGamepadAxisMovement(gamepad, axis);
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