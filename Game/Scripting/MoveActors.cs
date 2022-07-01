using Unit06.Game.Casting;


namespace Unit06.Game.Scripting
{
    /// An update action that moves all the actors.
    public class MoveActors : Action
    {
        /// Constructs a new instance of MoveActorsAction.
        public MoveActors()
        {
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            Player player2 = (Player) cast.GetFirstOfKey("player2");
            Player player1 = (Player) cast.GetFirstOfKey("player1");
            
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
            }
            player1.ExtendTrail();
            player2.ExtendTrail();
        }
    }
}