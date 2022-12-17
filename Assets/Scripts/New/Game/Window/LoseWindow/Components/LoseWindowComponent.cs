public class LoseWindowComponent : WindowComponent<ShootingRangeMiniGame>
{
    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<LoseWindow>(Prefab);
    }
}
