namespace Unit06.Game.Casting
{
    public class Wall : Actor
    {
        private int posX;
        private int posY;
        private int width;
        private int height;
        //Constructs a wall
        public Wall(int posX, int posY, int width, int height)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.SetSize(width, height);
            this.SetPosition(new Point(posX, posY));
        }
        
        //Returns the X position of the wall
        public int GetPosX()
        {
            return posX;
        }
        //Returns the Y position of the wall
        public int GetPosY()
        {
            return posY;
        }
        //Returns the wall's width
        public int GetWidth()
        {
            return width;
        }
        //Returns the wall's height
        public int GetHeight()
        {
            return height;
        }
    }
}