using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    /// The responsibility of DrawActorsAction is to draw each of the actors.</para>
    public class DrawActors : Action
    {
        private VideoService videoService;

        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        public DrawActors(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// 
        public void Execute(Cast cast, Script script)
        {
            List<Actor> players = cast.GetActors("players");
            List<Actor> bullets = cast.GetActors("bullets");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(players);
            
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}