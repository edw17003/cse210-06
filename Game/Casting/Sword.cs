namespace Unit06.Game.Casting
{
    /// <para>A sword to be held or thrown</para>
    
    public class Sword : Actor
    { 

        
        private Sprite sprite = new Sprite("Game/Assets/Sprites/sword.png", 1, 180);
        private int cooldown = 0;
        private int cdStart = 120;
        private int damage = 25;
        private int[] neutralSize = new int[] {64, 10};
        private bool thrown = false;
        /// Constructs a new instance of Sword.
        public Sword()
        {
            
            SetSprite(sprite);
            //SetSize(neutralSize[0], neutralSize[1]);
            
        }
        //Sets the current rotation of the Sword's sprite
        public void SetSpriteRotation(int rotate)
        {
            this.sprite.SetRotation(rotate);
        }
        //Returns the size of the neutral state of the sprite
        public int[] GetNeutralSize()
        {
            return this.neutralSize;
        }
        //Checks for collision
        public override bool Overlaps(Actor other)
        {
            float x0;
            float x1;
            float y0;
            float y1;
            if (this.GetLeft() > this.GetRight())
            {
                x0 = this.GetRight();
                x1 = this.GetLeft();
            } else {
                x1 = this.GetRight();
                x0 = this.GetLeft();
            }
            if (this.GetTop() < this.GetBottom())
            {
                y0 = this.GetBottom();
                y1 = this.GetTop();
            } else {
                y1 = this.GetBottom();
                y0 = this.GetTop();
            }
            return (x0 < other.GetRight() && x1 > other.GetLeft()
                 && y1 < other.GetBottom() && y0 > other.GetTop());
        }
        //Sets if the sword is currently being thrown
        public void SetIsThrown(bool thrown)
        {
            this.thrown = thrown;
            if (this.thrown)
            { 
                StartCooldown();
            } 
        }
        //Returns if the sword is being thrown
        public bool GetIsThrown()
        {
            return this.thrown;
        }
        //Decrements the sword throw's cooldown
        public void SetCooldown()
        {
            if (cooldown > 0) {
                this.cooldown--;
            }
            
            // if (this.cooldown == 0)
            // {
            //     this.thrown = false;
            // }
        }
        //Returns the value of the sword's current max cooldown value
        public int GetcdStart()
        {
            return this.cdStart;
        }
        //Returns the sword's current cooldown value
        public int GetCooldown()
        {
            return this.cooldown;
        }
        //Starts the sword throw cooldown
        private void StartCooldown()
        {
            this.cooldown = cdStart;
        }
        //Was going to decrease the velocity of the sword when it is in the air. Not used currently.
        public void DecreaseVelocity()
        {
            if (cooldown > 0)
            {
            // SetVelocity(new Point((int)(GetVelocity().GetX() - cdStart/(cooldown+1)), (int)(GetVelocity().GetY() - cdStart/(cooldown + 1))));
            }
        }
        //Returns the amount of damage the sword does
        public int GetDamage()
        {
            return this.damage;
        }
        //Increases the amount of damage the sword does
        public void SetDamage()
        {
            damage ++;
        }
    }
}