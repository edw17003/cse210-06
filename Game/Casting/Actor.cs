namespace Unit06.Game.Casting
{
    /// A thing that participates in the game.
    /// The responsibility of Actor is to keep track of its appearance, position and velocity
    /// in 2d space.
    public class Actor
    {
        private string text = "";
        private int fontSize = 15;
        private Color color = Constants.WHITE;
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);
        private Point size = new Point(0, 0);
        private Sprite sprite;

        /// Constructs a new instance of Actor.
        public Actor()
        {
        }

        /// Gets the actor's color.
        public Color GetColor()
        {
            return color;
        }

        /// Gets the actor's font size.
        public int GetFontSize()
        {
            return fontSize;
        }

        /// Gets the actor's position.
        public Point GetPosition()
        {
            return position;
        }

        /// Gets the actor's text.
        public string GetText()
        {
            return text;
        }

        /// Gets the actor's current velocity.
        public Point GetVelocity()
        {
            return velocity;
        }
        /// Gets the actor's left side coordinate
        public float GetLeft()
        {
            return position.GetX();
        }
        /// Gets the actor's right side coordinate
        public float GetRight()
        {
            return position.GetX() + size.GetX();
        }
        /// Gets the actor's top side coordinate
        public float GetTop()
        {
            return position.GetY();
        }
        /// Gets the actor's bottom side coordinate
        public float GetBottom()
        {
            return position.GetY() + size.GetY();
        }
        /// Returns a boolean of true if an actor overlaps or false if it does not
        public virtual bool Overlaps(Actor other)
        {
            return (this.GetLeft() < other.GetRight() && this.GetRight() > other.GetLeft()
                 && this.GetTop() < other.GetBottom() && this.GetBottom() > other.GetTop());
        }
        /// Returns a boolean of true if the left side is less than 5 pixels from overlapping inputted actor
        public bool OverlapsLeft(Actor other)
        {
            return (this.GetLeft() - 5 < other.GetRight() && this.GetRight() > other.GetLeft()
                 && this.GetTop() < other.GetBottom() && this.GetBottom() > other.GetTop());
        }
        /// Returns a boolean of true if the top side is less than 5 pixels from overlapping inputted actor
        public bool OverlapsTop(Actor other)
        {
            return (this.GetLeft() < other.GetRight() && this.GetRight() > other.GetLeft()
                 && this.GetTop() - 5 < other.GetBottom() && this.GetBottom() > other.GetTop());
        }
        /// Returns a boolean of true if the right side is less than 5 pixels from overlapping inputted actor
        public bool OverlapsRight(Actor other)
        {
            return (this.GetLeft() < other.GetRight() && this.GetRight() + 5 > other.GetLeft()
                 && this.GetTop() < other.GetBottom() && this.GetBottom() > other.GetTop());
        }
        /// Returns a boolean of true if the bottom side is less than 5 pixels from overlapping inputted actor
        public bool OverlapsBottom(Actor other)
        {
            return (this.GetLeft() < other.GetRight() && this.GetRight() > other.GetLeft()
                 && this.GetTop() < other.GetBottom() && this.GetBottom() + 5> other.GetTop());
        }

        /// Moves the actor to its next position according to its velocity. Will wrap the position 
        /// from one side of the screen to the other when it reaches the maximum x and y 
        /// values.
        public virtual void MoveNext()
        {
            int x = ((position.GetX() + velocity.GetX()) + Constants.MAX_X) % Constants.MAX_X;
            int y = ((position.GetY() + velocity.GetY()) + Constants.MAX_Y) % Constants.MAX_Y;
            position = new Point(x, y);                    
        }

        /// Sets the actor's color to the given value.
        public void SetColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentException("color can't be null");
            }
            this.color = color;
        }

        /// Sets the actor's font size to the given value.
        public void SetFontSize(int fontSize)
        {
            if (fontSize <= 0)
            {
                throw new ArgumentException("fontSize must be greater than zero");
            }
            this.fontSize = fontSize;
        }

        /// Sets the actor's position to the given value.
        public void SetPosition(Point position)
        {
            if (position == null)
            {
                throw new ArgumentException("position can't be null");
            }
            this.position = position;
        }

        /// Sets the actor's text to the given value.
        public void SetText(string text)
        {
            if (text == null)
            {
                throw new ArgumentException("text can't be null");
            }
            this.text = text;
        }

        /// Sets the actor's velocity to the given value.
        public void SetVelocity(Point velocity)
        {
            if (velocity == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            this.velocity = velocity;
        }
        /// Returns the sprite associated with the actor
        public Sprite GetSprite()
        {
            return this.sprite;
        }
        /// Sets the sprite of an actor to inputted sprite
        public void SetSprite(Sprite sprite)
        {
            this.sprite = sprite;
        }
        /// Sets the size of the actor as a Point
        public void SetSize(int x, int y)
        {
            this.size = new Point(x, y);
        }
        /// Returns the size of the actor as a Point
        public Point GetSize()
        {
            return this.size;
        }
    }
}