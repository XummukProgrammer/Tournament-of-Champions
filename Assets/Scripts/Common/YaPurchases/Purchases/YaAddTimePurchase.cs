public class YaAddTimePurchase : IYaPurchase
{
    public string GetId()
    {
        return "test";
    }

    public void Receive(Game game)
    {
        game.LoseTimer.AddTime(999);
    }
}
