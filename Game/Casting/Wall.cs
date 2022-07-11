namespace Unit06.Game.Casting
{
    public class Wall : Actor
    {
        private int posX;
        private int posY;
        private int width;
        private int height;
        public Wall(int posX, int posY, int width, int height)
        {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
            this.SetSize(width, height);
        }
        public override float GetLeft()
        {
            return posX;
        }
        public override float GetRight()
        {
            return posX + width;
        }
        public override float GetTop()
        {
            return posY;
        }
        public override float GetBottom()
        {
            return posY + height;
        }
    }
}