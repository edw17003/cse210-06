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

            Point direction = GetDirection(0);
            Point direction2 = GetDirection(1);
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];
            
            ControlVelocity(player1, direction);
            
            ControlVelocity(player2, direction2);

            player1.SetAngle(GetAngle(0));
            player2.SetAngle(GetAngle(1));

            Sword sword1 = (Sword)cast.GetActors("swords")[0];
            Sword sword2 = (Sword)cast.GetActors("swords")[1];
            
            sword1.SetPosition(player1.GetPosition());
            sword2.SetPosition(player2.GetPosition());
            sword1.SetSpriteRotation(player1.GetAngle());
            sword2.SetSpriteRotation(player2.GetAngle());
            
            CreateBullets(cast, player1, player2);

            player1.SetCooldown();
        }

        public Point GetDirection(int index)
        {
            return new Point((int)(gamepadService.GetLeftVector(index).X * 5), (int)(gamepadService.GetLeftVector(index).Y * 5));
        }

        public void ControlVelocity(Player player, Point direction)
        {
            player.SetVelocity(direction);
        }

        public int GetAngle(int index)
        {
            return (int)(180/Math.PI * (Math.Atan2(gamepadService.GetRightVector(index).Y, gamepadService.GetRightVector(index).X )));
        }

        public void CreateBullets(Cast cast, Player player1, Player player2)
        {
            if (gamepadService.IsButtonDown(0, "rt") && player1.GetCooldown() == 0)
            {
                cast.AddActor("bullets1", new Bullet(new Point((int)(gamepadService.GetRightVector(0).X*10), (int)(gamepadService.GetRightVector(0).Y * 10)), player1.GetPosition()));
            }
            if (gamepadService.IsButtonDown(1, "rt") && player2.GetCooldown() == 0)
            {
                cast.AddActor("bullets2", new Bullet(new Point((int)(gamepadService.GetRightVector(1).X*10), (int)(gamepadService.GetRightVector(1).Y * 10)), player2.GetPosition()));
            }
        }
    }
}