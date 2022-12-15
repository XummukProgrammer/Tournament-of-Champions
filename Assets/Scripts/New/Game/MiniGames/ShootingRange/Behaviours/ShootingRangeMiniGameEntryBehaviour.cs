public class ShootingRangeMiniGameEntryBehaviour : MiniGameEntryBehaviour
{
    public override MiniGame CreateMiniGame(MiniGamesManager miniGamesManager)
    {
        return miniGamesManager.CreateAndAddMiniGame<ShootingRangeMiniGame>(Components);
    }
}
