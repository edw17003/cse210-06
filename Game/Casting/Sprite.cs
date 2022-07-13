namespace Unit06.Game.Casting
{
    /// An image.
    public class Sprite
    {
        private string filename;
        private double scale;
        private int rotation;
        private bool flip = false;

        /// Constructs a new instance of Image.
        public Sprite(string filename, double scale = 1.0, int rotation = 0)
        {
            this.filename = filename;
            this.scale = scale;
            this.rotation = rotation;
        }

        /// Gets the filename.
        public string GetFilename()
        {
            return filename;
        }

        /// Gets the rotation.
         public int GetRotation()
        {
            return rotation;
        }

        /// Gets the scale.
        public double GetScale()
        {
            return scale;
        }

        //flip the sprite
        public void SetFlip(bool flip)
        {
            this.flip = flip;
        }
        //Get whether the sprite is flipped
        public bool GetFlip()
        {
            return this.flip;
        }

        /// Sets the rotation to the given value.
        public void SetRotation(int rotation)
        {
            this.rotation = rotation;
        }

        /// Sets the scale to the given value.
        public void SetScale(double scale)
        {
            this.scale = scale;
        }
        
    }
}