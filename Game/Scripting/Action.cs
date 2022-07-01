using Unit06.Game.Casting;


namespace Unit06.Game.Scripting 
{
    /// The responsibility of action is to do something that is integral or important in the game. 
    /// Thus, it has one method, Execute(...), which should be overridden by derived classes.
    public interface Action
    {
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        void Execute(Cast cast, Script script);
    }
}