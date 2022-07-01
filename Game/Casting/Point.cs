namespace Unit06.Game.Casting
{
    /// A distance from a relative origin (0, 0)
    /// The responsibility of Point is to hold and provide information about itself. Point has a few 
    /// convenience methods for adding, scaling, and comparing them.
    public class Point
    {
        private int x = 0;
        private int y = 0;

        /// Constructs a new instance of Point using the given x and y values.
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// Adds the given point to this one by summing the x and y values.
        public Point Add(Point other)
        {
            int x = this.x + other.GetX();
            int y = this.y + other.GetY();
            return new Point(x, y);
        }

        /// Whether or not this Point is equal to the given one.
        public bool Equals(Point other)
        {
            return this.x == other.GetX() && this.y == other.GetY();
        }

        /// Gets the value of the x coordinate.
        public int GetX()
        {
            return x;
        }

        /// Gets the value of the y coordinate.
        public int GetY()
        {
            return y;
        }

        /// Reverses the point by inverting both x and y values.
        public Point Reverse()
        {
            int x = this.x * -1;
            int y = this.y * -1;
            return new Point(x, y);
        }
        
        /// Scales the point by multiplying the x and y values by the provided factor.
        public Point Scale(int factor)
        {
            int x = this.x * factor;
            int y = this.y * factor;
            return new Point(x, y);
        }
    }
}