using Unit06.Game.Casting;
using Unit06.Game.Services;


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
<<<<<<< HEAD
            Sword sword1 = (Sword) swords[0];
            Sword sword2 = (Sword) swords[1];

=======
            int index = 0;
>>>>>>> acfe3ef37b47b9eeb6d3040550b483898453c361
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

            if (sword1.GetIsThrown())
            {
                sword1.SetVelocity();
            }
            if (sword2.GetIsThrown())
            {
                
            }
        }
    }
}