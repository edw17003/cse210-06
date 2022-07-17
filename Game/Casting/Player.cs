namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Player : Actor
    {
        private int cooldown = 0;
        private int cdStart = 120;
        private int angle = 0;
        private string color;

        private int health = 100;

        /// Constructs a new instance of Player.
        public Player(Sprite sprite, Point spawn, string color)
        {
            SetPosition(spawn);
            SetSprite(sprite);
            SetSize(64, 64);
            this.color = color;
        }
        public string GetPlayerColor()
        {
            return color;
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

        public void DamagePlayer(int damage)
        {
            this.health -= damage;
        }
        public void HealPlayer(int healing)
        {
            this.health += healing;
            if (this.health > 100 + Constants.max_overheal)
            {
                this.health = 100 + Constants.max_overheal;
            }
        }
    }
}