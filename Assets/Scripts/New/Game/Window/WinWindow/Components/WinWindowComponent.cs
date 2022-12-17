public class WinWindowComponent<T> : WindowComponent<T> where T : MiniGame
{
    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<WinWindow>(Prefab);
    }
}
