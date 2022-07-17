using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    /// <para>An input action that controls the snake.</para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    public class ControlActors : Action
    {
        private GamepadService gamepadService;
        private AudioService audioService;
        private Sound throwSound = new Sound(Constants.throwSound);


        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public ControlActors(GamepadService gamepadService, AudioService audioService)
        {
            this.gamepadService = gamepadService;
            this.audioService = audioService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            

            int index = 0;
            foreach( Player player in cast.GetActors("players"))
            {
                Point direction = GetDirection(index);
                player.SetVelocity(direction);
                player.SetAngle(GetAngle(index));
                Sword sword = (Sword)cast.GetActors("swords")[index];
                SetSwordPos(sword, player);
                // if (sword.GetIsThrown())
                // {
                //     Console.WriteLine($"{sword.GetPosition().GetX()}, {sword.GetPosition().GetY()}");   
                // }
                ThrowSword(sword, index);
                
                sword.SetSize((int)(Math.Cos(GetAngle(index) * Math.PI / 180) * 
                                sword.GetNeutralSize()[0] + Math.Sin(GetAngle(index) * Math.PI / 180) * 
                                sword.GetNeutralSize()[1]), 
                              (int)(Math.Sin(GetAngle(index) * Math.PI / 180) * 
                                sword.GetNeutralSize()[0] + Math.Cos(GetAngle(index) * Math.PI / 180) * 
                                sword.GetNeutralSize()[1]));
                // if (index == 1)
                // {
                //     Console.WriteLine($"{player.GetPosition().GetX()}, {player.GetPosition().GetY()}");
                // }
                //Console.WriteLine($"{sword.GetSize().GetX()}, {sword.GetSize().GetY()}");
                index++;
            }
        }

        private void ThrowSword(Sword sword, int index)
        {
            if (gamepadService.IsButtonDown(index, "rt") && sword.GetIsThrown() == false && sword.GetCooldown() == 0)
            {
                
                sword.SetIsThrown(true);
                if (gamepadService.GetRightVector(index).X == 0 && gamepadService.GetRightVector(index).Y == 0)
                { 
                    sword.SetIsThrown(false);
                } else {
                    audioService.PlaySound(throwSound);
                    sword.SetVelocity(new Point((int)(gamepadService.GetRightVector(index).X*10), (int)(gamepadService.GetRightVector(index).Y * 10)));
                }
            }
        }

        private void SetSwordPos(Sword sword, Player player)
        {
            if (!sword.GetIsThrown())
            {
                sword.SetPosition(SwordPosition(player.GetPosition()));
                sword.SetSpriteRotation(player.GetAngle());
            }
        }

        private Point GetDirection(int index)
        {
            return new Point((int)(gamepadService.GetLeftVector(index).X * Constants.PLAYERSPEED), 
            (int)(gamepadService.GetLeftVector(index).Y * Constants.PLAYERSPEED));
        }

        private int GetAngle(int index)
        {
            return (int)(180/Math.PI * (Math.Atan2(gamepadService.GetRightVector(index).Y, gamepadService.GetRightVector(index).X )));
        }

        private Point SwordPosition(Point player)
        {
            
            int X = player.GetX() + 27;
            int Y = player.GetY() + 27;
            return new Point(X, Y);
        }
    }
}