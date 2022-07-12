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

            foreach (Player player in players)
            {
                player.SetCooldown();
            }

            foreach (Sword sword in swords)
            {
                sword.SetCooldown();
            }
        }
    }
}