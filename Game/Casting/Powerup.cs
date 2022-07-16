namespace Unit06.Game.Casting
{
    class Powerup : Actor
    {
        private int effect;
        private int posX;
        private int posY;
        Random random = new Random();
        public Powerup(int posX, int posY)
        {
            effect = random.Next(1,4);
            this.SetSize(10,10);
            this.SetPosition(new Point(this.posX, this.posY));
        }
        public int getEffect()
        {
            return effect;
        }
        public int getPosX()
        {
            return posX;
        }
        public int getPosY()
        {
            return posY;
        }
        public void applyEffect(Cast cast, Player player)
        {
            switch (this.effect)
            {
                case 1:
                    Console.WriteLine("Applied effect 1");
                    break;
                case 2:
                    Console.WriteLine("Applied effect 2");
                    break;
                case 3:
                    Console.WriteLine("Applied effect 3");
                    break;
                case 4:
                    Console.WriteLine("Applied effect 4");
                    break;
            }
            Actor effect = cast.GetFirstOfKey("effect");
            cast.RemoveActor("powerup", effect);
        }
        public void spawnEffect(Cast cast)
        {
            // WIP
            int newX = random.Next(1,1590);
            int newY = random.Next(1,890);
            Powerup test = new Powerup(newX, newY);
            
            // List<Actor> walls = new List<Actor>(cast.GetAllActors("walls"));
        }
    }
}