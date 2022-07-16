namespace Unit06.Game.Scripting
{
    /// The responsibility of a script is to keep track of a collection of actions.
    public class Script
    {
        private Dictionary<string, List<Action>> actions = new Dictionary<string, List<Action>>();

        /// Constructs a new instance of Script.
        public Script()
        {
        }

        /// Adds the given action to the given group.
        public void AddAction(string group, Action action)
        {
            if (!actions.ContainsKey(group))
            {
                actions[group] = new List<Action>();
            }

            if (!actions[group].Contains(action))
            {
                actions[group].Add(action);
            }
        }

        /// Gets the actions in the given group. Returns an empty list if there aren't any.
        public List<Action> GetActions(string group)
        {
            List<Action> results = new List<Action>();
            if (actions.ContainsKey(group))
            {
                results.AddRange(actions[group]);
            }
            return results;
        }

        /// Removes the given action from the given group.
        public void RemoveAction(string group, Action action)
        {
            if (actions.ContainsKey(group))
            {
                actions[group].Remove(action);
            }
        }

        public void RemoveAllOfKey(string group)
        {
            actions[group].Clear();
        }
        
    }
}