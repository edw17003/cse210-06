namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Player : Actor
    {
        private Point spawn = new Point(0, 0);

        /// Constructs a new instance of Player.
        public Player(Sprite sprite, Point spawn)
        {
            SetPosition(spawn);
            SetSprite(sprite);
            SetSize(64, 64);
        }
    }
}