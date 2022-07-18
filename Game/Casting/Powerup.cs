namespace Unit06.Game.Casting
{
    /// The purpose of the Powerup class is to keep track of powerups to be collected by the players.
    class Powerup : Actor
    {
        private int effect;
        private int posX;
        private int posY;
        Random random = new Random();
        /// Powerup class constructor
        public Powerup(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            effect = random.Next(1,3);
            this.SetSize(32,32);
            this.SetPosition(new Point(this.posX, this.posY));
            this.SetSprite(new Sprite("Game/Assets/Sprites/powerup" + effect + ".png", 1, 0));
        }
        /// Returns the effect of the powerup
        public int GetEffect()
        {
            return effect;
        }
        /// Returns the x position of the powerup
        public int GetPosX()
        {
            return posX;
        }
        /// Returns the y position of the powerup
        public int GetPosY()
        {
            return posY;
        }
        /// Applies the affect of the powerup, given the cast, the player that collects it, and their sword
        public void ApplyEffect(Cast cast, Player player, Sword sword)
        {
            /// Depending on the value in effect, apply an effect
            switch (this.effect)
            {
                case 1:
                    player.HealPlayer(25);
                    break;
                case 2:
                    sword.SetDamage();
                    break;
            }
            /// Delete the powerup from the cast when it has been collected
            cast.RemoveActor("powerups", this);
        }
        /// Spawns a powerup where it does not collide with any other actors
        public void SpawnPowerup(Cast cast)
        {
            bool isSpawned = false;

            /// While it has not spawned a powerup, keep trying to find a location
            /// where it is not colliding with another actor in the cast
            while (!isSpawned)
            {
                /// Generate a new powerup at a random location
                int newX = random.Next(1, Constants.MAX_X - this.GetSize().GetX());
                int newY = random.Next(1, Constants.MAX_Y - this.GetSize().GetY());
                Powerup testPowerup = new Powerup(newX, newY);
                bool canSpawn = true;

                /// Test if any actor in the cast is colliding with the testPowerup
                foreach (Actor actor in cast.GetAllActors())
                {
                    /// If any actor collides with testPowerup, set canSpawn to false
                    if (testPowerup.Overlaps(actor))
                    {
                        canSpawn = false;
                    }
                }
                /// If no actors in the cast overlap the testPowerup, break out of the while loop add that powerup to the cast
                if (canSpawn)
                {
                    isSpawned = true;
                    cast.AddActor("powerups", testPowerup);
                }
            }    
        }
    }
}