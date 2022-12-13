public class YaAdsAddTimeReward : IYaAdsReward
{
    public string GetPlacement()
    {
        return "AddTime";
    }

    public void Receive(Game game)
    {
        game.LoseTimer.AddTime(999);
    }
}
