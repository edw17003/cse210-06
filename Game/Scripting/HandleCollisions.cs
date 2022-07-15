using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    /// An update action that handles interactions between the actors.
    public class HandleCollisions : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisions()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGameOver(cast);
                HandlePlayerCollisions(cast);
                HandleWallCollisions(cast);
                HandleSwordWallCollisions(cast);
            }
        }

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
                        Console.WriteLine("sword colliding with wall");
                        sword.SetIsThrown(false);
                    }
                }
            }
        }
        private void HandlePlayerCollisions(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            Player otherPlayer = player1;

            foreach (Player player in players)
            {
                if (player == (cast.GetActors("players")[0]))
                {
                    otherPlayer = player2;
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
            }
        }

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
                    }
                    if (player.OverlapsBottom(wall))
                    {
                        int yVelocity = player.GetVelocity().GetY();
                        if (yVelocity > 0)
                        {
                            yVelocity = 0;
                        }
                        player.SetVelocity(new Point(player.GetVelocity().GetX(), yVelocity));   
                    }
                    if (player.OverlapsLeft(wall))
                    {
                        int xVelocity = player.GetVelocity().GetX();
                        if (xVelocity < 0)
                        {
                            xVelocity = 0;
                        }
                        player.SetVelocity(new Point(xVelocity, player.GetVelocity().GetY()));  
                    }
                    if (player.OverlapsRight(wall))
                    {
                        int xVelocity = player.GetVelocity().GetX();
                        if (xVelocity > 0)
                        {
                            xVelocity = 0;
                        }
                        player.SetVelocity(new Point(xVelocity, player.GetVelocity().GetY())); 
                    } 
                }
            } 
        }

        public void HandlePlayerSwordCollisions(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];
            Sword sword1 = (Sword)cast.GetActors("swords")[0];
            Sword sword2 = (Sword)cast.GetActors("swords")[1];

            if (sword2.Overlaps(player1) && player2.GetCooldown() == 0)
                {
                      player1.SetHealth(25);
                      player1.StartCooldown();
                      Console.WriteLine("Sword2 Colliding with Player1");
                      sword2.SetIsThrown(false);           
                }
            if (sword1.Overlaps(player2) && player2.GetCooldown() == 0)
                {
                      player2.SetHealth(25);
                      player2.StartCooldown();
                      Console.WriteLine("Sword1 Colliding with Player2");
                      sword1.SetIsThrown(false);
                }
        }

        // Handles what happens if the game ends.
        // Turns the cycles and their trails white and 
        // displays the game over message.
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player player1 = (Player)cast.GetFirstOfKey("player1");
                Player player2 = (Player)cast.GetFirstOfKey("player2");

                // create a "game over" message
                int x = Constants.MAX_X / 2 - 110;
                int y = Constants.MAX_Y / 2 - 45;
                Point position = new Point(x, y);
                Color color = new Color(255, 0, 255);
                Actor message = new Actor();
                message.SetColor(color);
                message.SetFontSize(45);
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                // foreach (Actor segment in body1)
                // {
                //     segment.SetColor(Constants.WHITE);
                // }
                // foreach (Actor segment in body2)
                // {
                //     segment.SetColor(Constants.WHITE);
                // }
                player1.SetColor(Constants.WHITE);
                player2.SetColor(Constants.WHITE);
            }
        }

    }
}