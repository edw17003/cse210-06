using Unit06.Game.Casting;


namespace Unit06.Game.Scripting
{
    /// An update action that handles interactions between the actors.
    public class HandleCooldowns : Action
    {
        /// <summary>
        /// Constructs a new instance of HandleCooldownsAction.
        /// </summary>
        public HandleCooldowns()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> players = cast.GetActors("players"); 
            List<Actor> swords = cast.GetActors("swords");
            int index = 0;
            foreach (Player player in players)
            {
                
                player.SetCooldown();
                Sword sword = (Sword)swords[index];
                if (sword.GetCooldown() > (110))
                {
                    player.SetVelocity(new Point(0, 0));
                }
            }

            foreach (Sword sword in swords)
            {
                sword.SetCooldown();
            }
        }
    }
}