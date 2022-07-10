namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Player : Actor
    {
        private Point spawn = new Point(0, 0);
        private Point size = new Point(100, 100);

        private int angle = 0;

        /// Constructs a new instance of Player.
        public Player(Sprite sprite, Point spawn)
        {
            SetPosition(spawn);
            SetSprite(sprite);
        }

        public void SetAngle(int angle)
        {
            this.angle = angle;
        }

        public int GetAngle()
        {
            return this.angle;
        }
    }
}