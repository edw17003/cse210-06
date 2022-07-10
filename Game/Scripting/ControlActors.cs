using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    /// <para>An input action that controls the snake.</para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    public class ControlActors : Action
    {
        private GamepadService gamepadService;


        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public ControlActors(GamepadService gamepadService)
        {
            this.gamepadService = gamepadService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {

            Point direction = new Point((int)(gamepadService.GetLeftVector(0).X * 5), (int)(gamepadService.GetLeftVector(0).Y * 5));
            Point direction2 = new Point((int)(gamepadService.GetLeftVector(1).X * 5), (int)(gamepadService.GetLeftVector(1).Y * 5));
            Player player1 = (Player)cast.GetActors("players")[0];
            player1.SetVelocity(direction);
            Player player2 = (Player)cast.GetActors("players")[1];
            player2.SetVelocity(direction2);
            Sword sword1 = (Sword)cast.GetActors("swords")[0];
            Sword sword2 = (Sword)cast.GetActors("swords")[1];
            
            sword1.SetPosition(player1.GetPosition());
            sword2.SetPosition(player2.GetPosition());
            sword1.SetSpriteRotation((int)(360 * Math.Atan((gamepadService.GetRightVector(0).X / gamepadService.GetRightVector(0).Y )) / Math.PI));
            sword2.SetSpriteRotation((int)(360 * Math.Atan((gamepadService.GetRightVector(1).X / gamepadService.GetRightVector(1).Y )) / Math.PI));
        }
    }
}