using UnityEngine;

public class LoseTimerHUDComponent : HUDComponent
{
    protected override HUD CreateController(HUDManager hudManager)
    {
        return hudManager.CreateAndAddController<LoseTimerHUD>(Prefab, Location);
    }
}
