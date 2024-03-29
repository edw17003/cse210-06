using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    /// An update action that handles interactions between the actors.
    public class HandleCollisions : Action
    {
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisions()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            HandlePlayerCollisions(cast);
            HandleWallCollisions(cast);
            HandleSwordWallCollisions(cast);
            HandlePlayerSwordCollisions(cast);
            HandlePowerupCollisions(cast);
        }
        /// Handles when players collect powerups
        private void HandlePowerupCollisions(Cast cast)
        {
            List<Actor> players = cast.GetActors("players");
            List<Actor> powerups = cast.GetActors("powerups");
            List<Actor> swords = cast.GetActors("swords");
            int index = 0;

            foreach (Player player in players)
            {
                foreach (Powerup powerup in powerups)
                {
                    if (player.Overlaps(powerup))
                    {
                        powerup.ApplyEffect(cast, player, (Sword)swords[index]);
                    }
                }
                index ++;
            }
        }
        /// Handles when a sword collides with a wall
        private void HandleSwordWallCollisions(Cast cast)
        {
            List<Actor> swords = cast.GetActors("swords");
            List<Actor> walls = cast.GetActors("walls");
            foreach (Sword sword in swords)
            {
                foreach (Actor wall in walls)
                { 
                    if (sword.Overlaps(wall)) 
                    {
                        
                        sword.SetIsThrown(false);
                    }
                }
            }
        }
        /// Handles when a player collides with another player
        private void HandlePlayerCollisions(Cast cast)
        {
            
            int index = 0;
            foreach (Player player in cast.GetActors("players"))
            {
                Player otherPlayer;
                if (index == 0)
                {
                    otherPlayer = (Player)cast.GetActors("players")[1];
                } else {
                    otherPlayer = (Player)cast.GetActors("players")[0];
                }
                if (player.OverlapsTop(otherPlayer))
                {
                    int yVelocity = player.GetVelocity().GetY();
                    if (yVelocity < 0)
                    {
                        yVelocity = 0;
                    }
                    player.SetVelocity(new Point(player.GetVelocity().GetX(), yVelocity));
                } 
                if (player.OverlapsBottom(otherPlayer))
                {
                    int yVelocity = player.GetVelocity().GetY();
                    if (yVelocity > 0)
                    {
                        yVelocity = 0;
                    }
                    player.SetVelocity(new Point(player.GetVelocity().GetX(), yVelocity));   
                }   
                if (player.OverlapsLeft(otherPlayer))
                {
                    int xVelocity = player.GetVelocity().GetX();
                    if (xVelocity < 0)
                    {
                        xVelocity = 0;
                    }
                    player.SetVelocity(new Point(xVelocity, player.GetVelocity().GetY()));  
                }   
                if (player.OverlapsRight(otherPlayer))
                {
                    int xVelocity = player.GetVelocity().GetX();
                    if (xVelocity > 0)
                    {
                        xVelocity = 0;
                    }
                    player.SetVelocity(new Point(xVelocity, player.GetVelocity().GetY())); 
                }
                index++;
            }
        }
        /// Handles collisions between players and walls
        public void HandleWallCollisions(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            List<Actor> walls = cast.GetActors("walls");
            foreach (Player player in players)
            {
                foreach (Actor wall in walls)
                {
                    if (player.OverlapsTop(wall))
                    {
                        int yVelocity = player.GetVelocity().GetY();
                        if (yVelocity < 0)
                        {
                            yVelocity = 0;
                        }
                        player.SetVelocity(new Point(player.GetVelocity().GetX(), yVelocity));
                        //Console.WriteLine("Player is colliding.");
                    }
                    if (player.OverlapsBottom(wall))
                    {
                        int yVelocity = player.GetVelocity().GetY();
                        if (yVelocity > 0)
                        {
                            yVelocity = 0;
                        }
                        player.SetVelocity(new Point(player.GetVelocity().GetX(), yVelocity)); 
                        //Console.WriteLine("Player is colliding.");  
                    }
                    if (player.OverlapsLeft(wall))
                    {
                        int xVelocity = player.GetVelocity().GetX();
                        if (xVelocity < 0)
                        {
                            xVelocity = 0;
                        }
                        player.SetVelocity(new Point(xVelocity, player.GetVelocity().GetY()));  
                        //Console.WriteLine("Player is colliding.");
                    }
                    if (player.OverlapsRight(wall))
                    {
                        int xVelocity = player.GetVelocity().GetX();
                        if (xVelocity > 0)
                        {
                            xVelocity = 0;
                        }
                        player.SetVelocity(new Point(xVelocity, player.GetVelocity().GetY())); 
                        //Console.WriteLine("Player is colliding.");
                    } 
                }
            } 
        }
        /// Handles collisions between players and swords
        public void HandlePlayerSwordCollisions(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];
            Sword sword1 = (Sword)cast.GetActors("swords")[0];
            Sword sword2 = (Sword)cast.GetActors("swords")[1];

            if (sword2.Overlaps(player1) && player1.GetCooldown() == 0)
            {
                    player1.DamagePlayer(sword2.GetDamage());
                    player1.StartCooldown();
                    //Console.WriteLine("Sword2 Colliding with Player1");
                    sword2.SetIsThrown(false);           
            }
            if (sword1.Overlaps(player2) && player2.GetCooldown() == 0)
            {
                    player2.DamagePlayer(sword1.GetDamage());
                    player2.StartCooldown();
                    //Console.WriteLine("Sword1 Colliding with Player2");
                    sword1.SetIsThrown(false);
            }
        }
    }
}