namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Player : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private Point spawn = new Point(0, 0);
        private Sprite sprite;

        /// Constructs a new instance of Player.
        public Player(Sprite sprite, Point spawn)
        {
            this.spawn = spawn;
            this.sprite = sprite;
        }

        // Turns the player's cycle to face the given direction
        public void TurnCycle(Point direction)
        {
            SetVelocity(direction);
        }
    }
}