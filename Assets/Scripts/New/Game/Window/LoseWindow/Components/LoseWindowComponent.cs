public class LoseWindowComponent : WindowComponent
{
    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<LoseWindow>(Prefab);
    }
}
