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
                // debug(cast);
            }
        }
        private void debug(Cast cast)
        {
            Wall firstWall = (Wall) cast.GetFirstOfKey("walls");
            float l = firstWall.GetLeft();
            float r = firstWall.GetRight();
            float t = firstWall.GetTop();
            float b = firstWall.GetBottom();
            Console.WriteLine($"L:{l}, R:{r}, T:{t}, B:{b}");
        }
        private void HandlePlayerCollisions(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];
            if (player1.Overlaps(player2))
            {
                Console.WriteLine("Player1 is colliding with player2");
            }
        }

        public void HandleWallCollisions(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("players")[0];
            Player player2 = (Player)cast.GetActors("players")[1];

            List<Actor> walls = cast.GetActors("walls");
            foreach (Actor wall in walls)
            {
                if (player1.OverlapsXT(wall))
                {
                    Console.WriteLine("Player1 is colliding with a wall.");
                    int YV = player1.GetVelocity().GetY();
                    if (YV < 0)
                    {
                        YV = 0;
                    }
                    player1.SetVelocity(new Point(player1.GetVelocity().GetX(), YV));
                    
                }
                if (player1.OverlapsXB(wall))
                {
                    Console.WriteLine("Player1 is colliding with a wall.");
                    int YV = player1.GetVelocity().GetY();
                    if (YV > 0)
                    {
                        YV = 0;
                    }
                    player1.SetVelocity(new Point(player1.GetVelocity().GetX(), YV));
                    
                }
                
                if (player1.OverlapsYL(wall))
                {
                    Console.WriteLine("Player1 is colliding with a wall.");
                    int XV = player1.GetVelocity().GetX();
                    if (XV < 0)
                    {
                        XV = 0;
                    }
                    player1.SetVelocity(new Point(XV, player1.GetVelocity().GetY()));
                    
                }
                if (player1.OverlapsYR(wall))
                {
                    Console.WriteLine("Player1 is colliding with a wall.");
                    int XV = player1.GetVelocity().GetX();
                    if (XV > 0)
                    {
                        XV = 0;
                    }
                    player1.SetVelocity(new Point(XV, player1.GetVelocity().GetY()));
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