namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Sword : Actor
    { 

        /// Constructs a new instance of Player.
        private Sprite sprite = new Sprite("Game/Assets/Sprites/sword.png", 1, 180);
        private int cooldown = 0;
        private int cdStart = 120;

        private bool thrown = false;
        
        public Sword()
        {
            
            SetSprite(sprite);
            
        }

        public void SetSpriteRotation(int rotate)
        {
            this.sprite.SetRotation(rotate);
        }

        public void SetIsThrown(bool thrown)
        {
            this.thrown = thrown;
            if (this.thrown)
            { 
                StartCooldown();
            } 
        }

        public bool GetIsThrown()
        {
            return this.thrown;
        }

        public void SetCooldown()
        {
            if (cooldown > 0) {
                this.cooldown--;
            }
            
            if (this.cooldown == 0)
            {
                this.thrown = false;
            }
        }

        public int GetcdStart()
        {
            return this.cdStart;
        }

        public int GetCooldown()
        {
            return this.cooldown;
        }
        private void StartCooldown()
        {
            this.cooldown = cdStart;
        }
        public void DecreaseVelocity()
        {
            if (cooldown > 0)
            {
            // SetVelocity(new Point((int)(GetVelocity().GetX() - cdStart/(cooldown+1)), (int)(GetVelocity().GetY() - cdStart/(cooldown + 1))));
            }
        }
    }
}