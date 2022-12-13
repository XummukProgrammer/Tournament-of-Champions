using UnityEngine;

public class DebugWindowComponent : WindowComponent
{
    [SerializeField] private KeyCode _openKey;

    protected override Window CreateController(WindowManager windowManager)
    {
        return windowManager.CreateAndAddController<DebugWindow>(Prefab);
    }

    protected override void OnInit()
    {
        base.OnInit();

        SetOpenKey(_openKey);
    }

    private void SetOpenKey(KeyCode keyCode)
    {
        var controller = (DebugWindow)Controller;
        if (controller != null)
        {
            controller.SetOpenKey(keyCode);
        }
    }
}
