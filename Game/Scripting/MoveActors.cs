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
            
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
            }
        }
    }
}