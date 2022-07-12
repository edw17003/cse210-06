namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Sword : Actor
    { 

        /// Constructs a new instance of Player.
        private Sprite sprite = new Sprite("Game/Assets/Sprites/sword.png", 1, 180);
        private int cooldown = 360;

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
            if (thrown)
            {
                this.thrown = true;
            }
        }

        public bool GetIsThrown()
        {
            return this.thrown;
        }

        public void SetCooldown()
        {
            this.cooldown--;
            if (this.cooldown == 0)
            {
                this.thrown = false;
            }
        }

    }
}