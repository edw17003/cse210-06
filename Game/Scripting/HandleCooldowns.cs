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
            Sword sword1 = (Sword) swords[0];
            Sword sword2 = (Sword) swords[1];

            foreach (Player player in players)
            {
                player.SetCooldown();
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