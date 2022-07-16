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
            this.posX = posX;
            this.posY = posY;
            effect = random.Next(1,4);
            this.SetSize(32,32);
            this.SetPosition(new Point(this.posX, this.posY));
            this.SetSprite(new Sprite("Game/Assets/Sprites/powerup.png", 1, 0));
        }
        public int GetEffect()
        {
            return effect;
        }
        public int GetPosX()
        {
            return posX;
        }
        public int GetPosY()
        {
            return posY;
        }
        public void ApplyEffect(Cast cast, Player player)
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
            Actor powerup = cast.GetFirstOfKey("powerup");
            cast.RemoveActor("powerup", powerup);
        }
        public void SpawnPowerup(Cast cast)
        {
            bool cannotSpawn = true;

            while (cannotSpawn)
            {
                int newX = random.Next(1, Constants.MAX_X - this.GetSize().GetX());
                int newY = random.Next(1, Constants.MAX_Y - this.GetSize().GetY());
                Powerup testPowerup = new Powerup(newX, newY);

                foreach (Actor actor in cast.GetAllActors())
                {
                    if (!testPowerup.Overlaps(actor))
                    {
                        cannotSpawn = false;
                    }
                }
                if (!cannotSpawn)
                {
                    cast.AddActor("powerups", testPowerup);
                }
            }
        }
        public bool IsPowerupPresent(Cast cast)
        {
            List<Actor> powerups = new List<Actor>(cast.GetActors("powerup"));
            return powerups.Count != 0;
        }
    }
}