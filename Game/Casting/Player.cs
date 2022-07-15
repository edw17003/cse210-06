namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Player : Actor
    {
        private int cooldown = 0;
        private int cdStart = 120;
        private int angle = 0;
        

        private int health = 100;

        /// Constructs a new instance of Player.
        public Player(Sprite sprite, Point spawn)
        {
            SetPosition(spawn);
            SetSprite(sprite);
            SetSize(64, 64);
        }

        public void SetAngle(int angle)
        {
            this.angle = angle;
        }

        public int GetAngle()
        {
            return this.angle;
        }

        public void SetCooldown()
        {
            if (cooldown > 0)
            {
                cooldown--;
            }
        }

        public void StartCooldown()
        {
            this.cooldown = cdStart;
        }

        public int GetCooldown()
        {
            return this.cooldown;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public void SetHealth(int damage)
        {
            this.health -= damage;
        }
    }
}