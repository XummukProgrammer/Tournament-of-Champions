// TODO: ƒобавить взаимодействие с мини-игрой

public class YaAdsAddTimeReward : IYaAdsReward
{
    public string GetPlacement()
    {
        return "AddTime";
    }

    public void Receive(EntryPoint entryPoint)
    {
        //game.LoseTimer.AddTime(999);
    }
}
