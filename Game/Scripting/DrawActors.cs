using Unit06.Game.Casting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting
{
    /// The responsibility of DrawActors is to draw each of the actors.</para>
    public class DrawActors : Action
    {
        private VideoService videoService;

        /// Constructs a new instance of DrawActors using the given VideoService.
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
            List<Actor> walls = cast.GetActors("walls");
            List<Actor> powerups = cast.GetActors("powerups");
            Player player1 = (Player)players[0];
            Player player2 = (Player)players[1];
            Sprite sprite1 = player1.GetSprite();
            Sprite sprite2 = player2.GetSprite();

            videoService.ClearBuffer();
            //Draw the background first
            videoService.DrawBackground();
            //Draw each powerup
            foreach (Powerup powerup in powerups)
            {
                videoService.DrawImage(powerup.GetSprite(), powerup.GetPosition());
            }
            //Draw the players
            videoService.DrawImage(players[0].GetSprite(), players[0].GetPosition());
            videoService.DrawImage(players[1].GetSprite(), players[1].GetPosition());
            //Draw the swords
            videoService.DrawImage(swords[0].GetSprite(), swords[0].GetPosition());
            videoService.DrawImage(swords[1].GetSprite(), swords[1].GetPosition());
            // videoService.DrawHitbox(swords[0]);
            // videoService.DrawHitbox(swords[1]);
            
            //Draw the walls, messages, and health bars.
            videoService.DrawWalls(walls);
            videoService.DrawActors(messages);
            videoService.DrawHealth(player1, Raylib_cs.Color.GREEN);
            videoService.DrawHealth(player2, Raylib_cs.Color.RED);
            videoService.FlushBuffer();
        }
    }
}