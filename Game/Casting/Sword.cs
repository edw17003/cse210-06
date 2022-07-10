namespace Unit06.Game.Casting
{
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    public class Sword : Actor
    { 

        /// Constructs a new instance of Player.
        
        public Sword()
        {
            Sprite sprite = new Sprite("Game/Assets/Sprites/sword.png", 1, 0);
            SetSprite(sprite);
        }
    }
}