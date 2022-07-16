using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    class SpawnPowerup : Action
    {
        Powerup powerup = new Powerup(-100,-100);
    public SpawnPowerup()
    {

    }
    public void Execute(Cast cast, Script script)
    {
        List<Actor> powerups = new List<Actor>(cast.GetActors("powerups"));
        if (powerups.Count == 0)
        {
            powerup.SpawnPowerup(cast);
        }
    }
    }
}