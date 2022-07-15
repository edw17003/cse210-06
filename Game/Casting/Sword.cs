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
        private int[] neutralSize = new int[] {64, 10};
        private bool thrown = false;
        
        public Sword()
        {
            
            SetSprite(sprite);
            //SetSize(neutralSize[0], neutralSize[1]);
            
        }

        public void SetSpriteRotation(int rotate)
        {
            this.sprite.SetRotation(rotate);
        }

        public int[] GetNeutralSize()
        {
            return this.neutralSize;
        }

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