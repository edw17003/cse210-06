using Unit06.Game.Casting;
using Unit06.Game.Services;
using Raylib_cs;

namespace Unit06.Game.Scripting
{
    public class CheckGamepad : Action
    {
        private GamepadService gamepadService = new GamepadService();
        public void Execute(Cast cast, Script script)
        {
            Console.WriteLine($"Gamepad detected: {gamepadService.IsGamepadAvailable(0)}");
        }
    }
}