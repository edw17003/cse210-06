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
            List<Actor> swords = cast.GetActors("swords");
            List<Actor> messages = cast.GetActors("messages");
            List<Actor> bullets1 = cast.GetActors("bullets1");
            List<Actor> bullets2 = cast.GetActors("bullets2");
            List<Actor> walls = cast.GetActors("walls");
            Player player1 = (Player)players[0];
            Player player2 = (Player)players[1];
            Sprite sprite1 = player1.GetSprite();
            Sprite sprite2 = player2.GetSprite();
            
            videoService.ClearBuffer();
            videoService.DrawImage(players[0].GetSprite(), players[0].GetPosition());
            videoService.DrawImage(players[1].GetSprite(), players[1].GetPosition());
            
            videoService.DrawImage(swords[0].GetSprite(), swords[0].GetPosition());
            videoService.DrawImage(swords[1].GetSprite(), swords[1].GetPosition());
            foreach (Bullet bullet in bullets1)
            {
                videoService.DrawImage(bullet.GetSprite(), bullet.GetPosition());
                bullet.UpdateLifespan();
                if (bullet.GetLifespan() == 0)
                {
                    cast.RemoveActor("bullets1", bullet);
                }
            }
            foreach (Bullet bullet in bullets2)
            {
                videoService.DrawImage(bullet.GetSprite(), bullet.GetPosition());
                bullet.UpdateLifespan();
                if (bullet.GetLifespan() == 0)
                {
                    cast.RemoveActor("bullets2", bullet);
                }
            }
            videoService.DrawActors(messages);
            videoService.DrawWalls(walls);
            videoService.FlushBuffer();
        }
    }
}