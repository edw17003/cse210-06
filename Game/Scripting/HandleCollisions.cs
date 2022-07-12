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
                } else {
                    otherPlayer = player1;
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



        

        // Handles what happens if the game ends.
        // Turns the cycles and their trails white and 
        // displays the game over message.
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player player1 = (Player)cast.GetFirstOfKey("player1");
                Player player2 = (Player)cast.GetFirstOfKey("player2");
                // List<Actor> body1 = player1.GetSegments();
                // List<Actor> body2 = player2.GetSegments();

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