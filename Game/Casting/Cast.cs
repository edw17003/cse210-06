namespace Unit06.Game.Casting
{
    /// A collection of actors.
    /// The responsibility of a cast is to keep track of a collection of actors. It has methods for 
    /// adding, removing and getting them by a group name.
    public class Cast
    {
        private Dictionary<string, List<Actor>> actors = new Dictionary<string, List<Actor>>();

        /// Constructs a new instance of Cast.
        public Cast()
        {
        }

        /// Adds the given actor to the given group.
        public void AddActor(string group, Actor actor)
        {
            if (!actors.ContainsKey(group))
            {
                actors[group] = new List<Actor>();
            }

            if (!actors[group].Contains(actor))
            {
                actors[group].Add(actor);
            }
        }

        /// Gets the actors in the given group. Returns an empty list if there aren't any.
        public List<Actor> GetActors(string group)
        {
            List<Actor> results = new List<Actor>();
            if (actors.ContainsKey(group))
            {
                results.AddRange(actors[group]);
            }
            return results;
        }

        /// Gets all the actors in the cast.
        public List<Actor> GetAllActors()
        {
            List<Actor> results = new List<Actor>();
            foreach (List<Actor> result in actors.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        /// Gets the first actor in the given group.
        public Actor GetFirstOfKey(string group)
        {
            Actor result = null;
            if (actors.ContainsKey(group))
            {
                if (actors[group].Count > 0)
                {
                    result = actors[group][0];
                }
            }
            return result;
        }

        /// Removes the given actor from the given group.
        public void RemoveActor(string group, Actor actor)
        {
            if (actors.ContainsKey(group))
            {
                actors[group].Remove(actor);
            }
        }

    }
}