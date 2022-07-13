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
            int index = 0;
            foreach( Player player in cast.GetActors("players"))
            {
                Point direction = GetDirection(index);
                ControlVelocity(player, direction);
                player.SetAngle(GetAngle(index));
                if (player.GetVelocity().GetX() > 0)
                {
                    player.GetSprite().SetFlip(false);
                } else {
                    player.GetSprite().SetFlip(true);
                }
                Sword sword = (Sword)cast.GetActors("swords")[index];
                PositionSword(sword, player);
                ThrowSword(sword, index);
                index++;
            }
        }

        private Point GetDirection(int index)
        {
            return new Point((int)(gamepadService.GetLeftVector(index).X * 5), (int)(gamepadService.GetLeftVector(index).Y * 5));
        }

        private void ControlVelocity(Player player, Point direction)
        {
            player.SetVelocity(direction);
        }

        private int GetAngle(int index)
        {
            return (int)(180/Math.PI * (Math.Atan2(gamepadService.GetRightVector(index).Y, gamepadService.GetRightVector(index).X )));
        }

        private void ThrowSword(Sword sword, int index)
        {
            if (gamepadService.IsButtonDown(index, "rt") && sword.GetIsThrown() == false && sword.GetCooldown() == 0)
            {
                sword.SetIsThrown(true);
                sword.SetVelocity(new Point((int)(gamepadService.GetRightVector(index).X*10), (int)(gamepadService.GetRightVector(0).Y * 10)));
            }
            
        }

        private void PositionSword(Sword sword, Player player)
        {
            if (!sword.GetIsThrown())
            {
                sword.SetPosition(SwordPosition(player.GetPosition()));
                sword.SetSpriteRotation(player.GetAngle());
            }
        }

        private Point SwordPosition(Point player)
        {
            
            int X = player.GetX() + 27;
            int Y = player.GetY() + 27;
            return new Point(X, Y);
        }
    }
}