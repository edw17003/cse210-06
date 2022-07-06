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
            Player player1 = (Player)players[0];
            Player player2 = (Player)players[1];
            Sprite sprite1 = player1.GetSprite();
            Sprite sprite2 = player2.GetSprite();
            videoService.ClearBuffer();
            videoService.DrawImage(sprite1, players[0].GetPosition());
            videoService.DrawImage(sprite2, players[1].GetPosition());
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}