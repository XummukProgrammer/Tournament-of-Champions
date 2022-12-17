public class LoseWindowComponent<T> : WindowComponent<LoseWindow, T> where T : MiniGame
{
    protected void OnGameLose()
    {
        Controller.OnGameLose();
    }
}
