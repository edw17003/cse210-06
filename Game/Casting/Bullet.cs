namespace Unit06.Game.Casting
{

    public class Bullet : Actor
    {
        private Sprite sprite = new Sprite("Game/Assets/Sprites/bullet.png", .5, 0);
        private int lifespan = 400;
        public Bullet(Point direction, Point position)
        {
            SetPosition(position);
            SetVelocity(direction);
        }

        public void UpdateLifespan()
        {
            this.lifespan--;
        }
        public int GetLifespan()
        {
            return this.lifespan;
        }
    }
}