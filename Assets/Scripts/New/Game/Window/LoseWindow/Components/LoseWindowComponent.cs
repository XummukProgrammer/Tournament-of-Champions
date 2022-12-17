public class LoseWindowComponent<T> : WindowComponent<T> where T : MiniGame
{
    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<LoseWindow>(Prefab);
    }

    protected void OnGameLose()
    {
        (Controller as LoseWindow).OnGameLose();
    }
}
