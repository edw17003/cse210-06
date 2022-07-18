namespace Unit06.Game.Casting
{
    /// <para>A player that moves</para>
    
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
        //Returns the color of the player
        public string GetPlayerColor()
        {
            return color;
        }
        //Sets the current angle of the player
        public void SetAngle(int angle)
        {
            this.angle = angle;
        }
        //Gets the current angle of the player
        public int GetAngle()
        {
            return this.angle;
        }
        //Decrements the hit cooldown of the player
        public void SetCooldown()
        {
            if (cooldown > 0)
            {
                cooldown--;
            }
        }
        //Starts the cooldown for the player not being able to be hit
        public void StartCooldown()
        {
            this.cooldown = cdStart;
        }
        //Returns the current cooldown value
        public int GetCooldown()
        {
            return this.cooldown;
        }
        //Returns the player's current health
        public int GetHealth()
        {
            return this.health;
        }
        //Decreases the player's current hp
        public void DamagePlayer(int damage)
        {
            this.health -= damage;
        }
        //Heals the player
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