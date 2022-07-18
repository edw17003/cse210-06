using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    /// <para>Player and sword movement.</para>
    /// The responsibility of ControlActors is to move the players and the swords.
    public class ControlActors : Action
    {
        private GamepadService gamepadService;
        private AudioService audioService;
        private Sound throwSound = new Sound(Constants.throwSound);


        /// Constructs a new instance of ControlActors.
        public ControlActors(GamepadService gamepadService, AudioService audioService)
        {
            this.gamepadService = gamepadService;
            this.audioService = audioService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            
            //Index required to get the correct gamepad for each player
            int index = 0;
            foreach( Player player in cast.GetActors("players"))
            {
                //Get the direction and set the player's velocity and angle
                Point direction = GetDirection(index);
                player.SetVelocity(direction);
                player.SetAngle(GetAngle(index));
                //Get the sword value and sets and throws the sword
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
        //throws the sword if the player has their right joystick pointed in a direction
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

        //Sets the sword's position if the sword is currently supposed to be attached to the player
        private void SetSwordPos(Sword sword, Player player)
        {
            if (!sword.GetIsThrown())
            {
                sword.SetPosition(SwordPosition(player.GetPosition()));
                sword.SetSpriteRotation(player.GetAngle());
            }
        }
        //Returns a point based on the left joystick's direction
        private Point GetDirection(int index)
        {
            return new Point((int)(gamepadService.GetLeftVector(index).X * Constants.PLAYERSPEED), 
            (int)(gamepadService.GetLeftVector(index).Y * Constants.PLAYERSPEED));
        }

        //Returns the angle of the right joystick
        private int GetAngle(int index)
        {
            return (int)(180/Math.PI * (Math.Atan2(gamepadService.GetRightVector(index).Y, gamepadService.GetRightVector(index).X )));
        }
        //Returns the point that the sword should be positioned at
        private Point SwordPosition(Point player)
        {
            
            int X = player.GetX() + 27;
            int Y = player.GetY() + 27;
            return new Point(X, Y);
        }
    }
}