using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    /// <para>An input action that controls the snake.</para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    public class ControlActors : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(0, -Constants.CELL_SIZE);
        private Point direction2 = new Point(0, -Constants.CELL_SIZE);

        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public ControlActors(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {   
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            Player player1 = (Player)cast.GetActors("players")[0];
            player1.SetVelocity(direction);

            // left
            if (keyboardService.IsKeyDown("j"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }

            
            Player player2 = (Player)cast.GetActors("players")[1];
            player2.SetVelocity(direction2);
            
            if (keyboardService.IsKeyDown("e"))
            {
                Bullet bullet = new Bullet(direction, player1.GetPosition());
                cast.AddActor("bullets", bullet);
            }
            if (keyboardService.IsKeyDown("o"))
            {
                Bullet bullet = new Bullet(direction, player2.GetPosition());
                cast.AddActor("bullets", bullet);
            }
        }
    }
}