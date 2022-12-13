public class WinWindowComponent : WindowComponent
{
    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<WinWindow>(Prefab);
    }
}
