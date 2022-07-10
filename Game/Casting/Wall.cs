namespace Unit06.Game.Casting
{
    public class Wall : Actor
    {
        private int posX;
        private int posY;
        private int width;
        private int height;
        public Wall(int posX, int posY, int height, int width)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.SetSize(width, height);
        }
        
        public int GetPosX()
        {
            return posX;
        }
        public int GetPosY()
        {
            return posY;
        }
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }
        public override float GetLeft()
        {
            return GetPosX();
        }
        public override float GetRight()
        {
            return GetPosY() + GetWidth();
        }
        public override float GetTop()
        {
            return GetPosY();
        }
        public override float GetBottom()
        {
            return GetPosY() + GetHeight();
        }
    }
}