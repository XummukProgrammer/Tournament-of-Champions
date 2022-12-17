public class WinWindowComponent : WindowComponent<ShootingRangeMiniGame>
{
    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<WinWindow>(Prefab);
    }
}
