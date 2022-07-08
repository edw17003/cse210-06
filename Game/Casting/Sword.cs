namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Sword : Actor
    {
        private Point spawn = new Point(0, 0);
        private Sprite sprite = new Sprite("sword.png", 1, 0);

        /// Constructs a new instance of Player.
        public Sword()
        {
            SetSprite(sprite);
        }
    }
}